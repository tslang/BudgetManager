module BudgetManager.Transaction {
    'use strict';

    export interface ITransactionIndexController {
        title: string;
        transactions: any[];
        isLoading: boolean;
    }

    export class TransactionIndexController implements ITransactionIndexController {
        title: string = 'Transaction';
        transactions: any[] = [];
        isLoading: boolean = false;

        public static $inject: string[] = ['$state', 'transactionService'];

        constructor(private $state: angular.ui.IStateService, transactionService: ITransactionService) {
            this.isLoading = true;

            transactionService.getAll().then((response: any) => {
                this.transactions = response.data;
            }).finally(() => {
                this.isLoading = false;
            });
        }
    }

    angular
        .module('budgetManager.transaction')
        .controller('transactionIndexController', TransactionIndexController);
}