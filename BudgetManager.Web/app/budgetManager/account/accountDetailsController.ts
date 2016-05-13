module BudgetManager.Account {
    'use strict';

    export interface IAccountDetailsController {
        title: string;
        account: any;
    }

    export interface IAccountDetailsStateParams {
        id: number;
    }

    export class AccountDetailsController implements IAccountDetailsController {
        public title: string = 'Account Details';
        public account: any;

        public static $inject: string[] = ['$stateParams', 'accountService'];

        constructor($stateParams: IAccountDetailsStateParams, private accountService: Account.IAccountService) {
            this.accountService.getDetail($stateParams.id).then((response: angular.IHttpPromiseCallbackArg<any>) => {
                this.account = response.data;
            });
        }
    }

    angular.module('budgetManager').controller('accountDetailsController', AccountDetailsController);
}