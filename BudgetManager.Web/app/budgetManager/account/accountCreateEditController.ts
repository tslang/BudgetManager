module BudgetManager.Account {
    'use strict';

    export interface IAccountCreateEditController {
        title: string;
        serverErrorMessages: any[];
        account: Account.IAccountCreateEditCommandModel;
        transactions: any[];
        isSaving: boolean;
        editForm: IAccountCreateEditControllerForm;
        save(): void;
    }

    export interface IAccountCreateEditControllerForm extends angular.IFormController {
        name: any;
    }

    export class AccountCreateEditController implements IAccountCreateEditController {
        public title: string = 'Accounts';
        public serverErrorMessages: any[] = [];
        public account: Account.IAccountCreateEditCommandModel = <IAccountCreateEditCommandModel>{ id: 0 };
        public transactions: any[] = [];
        public isSaving: boolean = false;
        public editForm: IAccountCreateEditControllerForm;

        public static $inject: string[] = ['$state', '$stateParams', 'accountService', 'coreFormsService', 'coreToast'];

        constructor(private $state: angular.ui.IStateService,
            $stateParams: Core.IIdStateParams,
            private accountService: IAccountService,
            private coreFormsService: Core.ICoreFormsService,
            private coreToast: Core.ICoreToast) {

            if ($stateParams.id) {
                this.accountService.getDetails($stateParams.id)
                    .then((response: angular.IHttpPromiseCallbackArg<IAccountDetailsViewModel>) => {
                        this.account = response.data;
                    });
            }

        }

        public save(): void {
            // check the form valid just in case someone submits a form before triggering the
            // client side validation with $dirty
            // (e.g. goes into create page and immediately clicks save button)
            if (this.editForm.$valid === true) {
                // convert selected tag objects into strings

                this.isSaving = true;

                if (this.account.id === 0) {
                    let accountCreateCommandModel: Account.IAccountCreateEditCommandModel = this.mapForCreate();
                    this.accountService.create(accountCreateCommandModel)
                        .then(() => {
                            this.coreToast.success(this.account.name + ' Added Successfully', this.account.name, 'Add');
                            this.$state.go('accountIndex');
                        },
                        (response: any) => {
                            this.serverErrorMessages = this.coreFormsService.parseErrorMessagesFromModelStateErrorResponse(response);
                        })
                        .finally(() => {
                            this.isSaving = false;
                        });
                } else {
                    let accountEditCommandModel: IAccountCreateEditCommandModel = this.mapForEdit();
                    this.accountService.edit(accountEditCommandModel)
                        .then(() => {
                            this.coreToast.success(this.account.name + ' Saved Successfully', this.account.name, 'Save');
                            this.$state.go('accountIndex');
                        },
                        (response: any) => {
                            this.serverErrorMessages = this.coreFormsService.parseErrorMessagesFromModelStateErrorResponse(response);
                        })
                        .finally(() => {
                            this.isSaving = false;
                        });
                }
            } else {
                this.coreFormsService.setRequiredFieldsDirty(this.editForm);
            }
        }


        private mapForCreate(): Account.IAccountCreateEditCommandModel {
            return <Account.IAccountCreateEditCommandModel>{
                name: this.account.name,
                bank: this.account.bank,
                amount: this.account.amount
            };
        }

        private mapForEdit(): Account.IAccountCreateEditCommandModel {
            return <Account.IAccountCreateEditCommandModel>{
                id: this.account.id,
                name: this.account.name,
                bank: this.account.bank,
                amount: this.account.amount
            };
        }
    }

    angular.module('budgetManager.account')
        .controller('accountCreateEditController', AccountCreateEditController);
}
