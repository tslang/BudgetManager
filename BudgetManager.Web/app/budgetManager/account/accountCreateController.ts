module BudgetManager.Account {
    'use strict';

    export interface IAccountCreateController {
        title: string;
        serverErrorMessages: any[];
        account: Account.IAccountCreateCommandModel;
        transactions: any[];
        isSaving: boolean;
        editForm: angular.IFormController;
        save(): void;
    }

    export class AccountCreateController implements IAccountCreateController {
        public title: string = 'Accounts';
        public serverErrorMessages: any[] = [];
        public account: Account.IAccountCreateCommandModel = <IAccountCreateCommandModel>{};
        public transactions: any[] = [];
        public isSaving: boolean = false;
        public editForm: angular.IFormController;

        public static $inject: string[] = ['$state', 'accountService', 'coreFormsService', 'coreToast'];

        constructor(private $state: angular.ui.IStateService,
            private accountService: IAccountService,
            private coreFormsService: Core.ICoreFormsService,
            private coreToast: Core.ICoreToast) {

        }

        public save(): void {
            if (this.editForm.$valid === false) {
                this.coreFormsService.setRequiredFieldsDirty(this.editForm);
                return;
            }
            this.isSaving = true;

            var accountCreateCommandModel: Account.IAccountCreateCommandModel = this.mapForCreate();
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
        }


        private mapForCreate(): Account.IAccountCreateCommandModel {
            return <Account.IAccountCreateCommandModel>{
                name: this.account.name,
                bank: this.account.bank,
                amount: this.account.amount
            };
        }
    }

    angular.module('budgetManager.account')
        .controller('accountCreateController', AccountCreateController);
}
