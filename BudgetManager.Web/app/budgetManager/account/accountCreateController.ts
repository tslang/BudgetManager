namespace BudgetManager.Account {
    'use strict';

    export interface IAccountCreateController {
        title: string;
        serverErrorMessages: any[];
        account: any;
        isSaving: boolean;
        createForm: angular.IFormController;
        save(): void;
    }

    export class AccountCreateController implements IAccountCreateController {
        public title: string = 'Accounts';
        public serverErrorMessages: any[] = [];
        public account: any;
        public isSaving: boolean = false;
        public createForm: angular.IFormController;

        public static $inject: string[] = ['$state', 'accountService', 'coreFormsService', 'coreToast'];

        constructor(private $state: angular.ui.IStateService,
            private accountService: Account.IAccountService,
            private coreFormsService: Core.ICoreFormsService,
            private coreToast: Core.ICoreToast) {

        }

        public save(): void {
            if (this.createForm.$invalid) {
                this.coreFormsService.setRequiredFieldsDirty(this.createForm);
                return;
            }
            this.isSaving = true;

            var accountCreateCommandModel: Account.IAccountCreateCommandModel = this.mapForCreate();
            this.accountService.create(accountCreateCommandModel)
                .then(() => {

                this.coreToast.success(`${this.account.name} added successfully!`, null, null);
                this.$state.go('accountIndex');
            },
                (response: any) => {
                    this.serverErrorMessages = this.coreFormsService.parseErrorMessagesFromModelStateErrorResponse(response);
                }).finally(() => {
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
}
