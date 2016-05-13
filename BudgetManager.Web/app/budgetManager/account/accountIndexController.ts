module BudgetManager.Account {
    'use strict';

    export interface IAccountIndexController {
        title: string;
        accounts: any[];
        isLoading: boolean;
    }

    export class AccountIndexController implements IAccountIndexController {
        title: string = "Account";
        public accounts: any[] = [];
        isLoading: boolean = false;

        public static $inject: string[] = ['$state', 'accountService'];

        constructor(private $state: angular.ui.IStateProvider, accountService: IAccountService) {
            this.isLoading = true;

            accountService.getAll().then((response: any) => {
                this.accounts = response.data;
            }).finally(() => {
                this.isLoading = false;
            });
        }
    }

    angular
        .module('budgetManager.account')
        .controller('accountIndexController', AccountIndexController);
}