module BudgetManager.Account {
    'use strict';

    export interface IAccountDetailsController {
        title: string;
        account: Account.IAccountDetailsViewModel;
    }

    export class AccountDetailsController implements IAccountDetailsController {
        public title: string = 'Account Details';
        public account: Account.IAccountDetailsViewModel;

        public static $inject: string[] = ['$stateParams', 'accountService'];

        constructor($stateParams: Core.IIdStateParams,
            private accountService: Account.IAccountService) {

            //this.accountService.getDetails($stateParams.id)
            //    .then((response: angular.IHttpPromiseCallbackArg<IAccountDetailsViewModel>) => {
            //    this.account = response.data;
            //});
            if ($stateParams.id) {
                this.accountService.getDetails($stateParams.id)
                    .then((response: angular.IHttpPromiseCallbackArg<IAccountDetailsViewModel>) => {
                        this.account = response.data;
                    });
            }
        }
    }

    angular.module('budgetManager')
        .controller('accountDetailsController', AccountDetailsController);
}