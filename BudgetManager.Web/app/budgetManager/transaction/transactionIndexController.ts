module BudgetManager.Transaction {
    'use strict';

    export interface ITransactionIndexController {
        title: string;
    }

    export class TransactionIndexController implements ITransactionIndexController {
        title: string = 'Transaction View';

        public static $inject: string[] = ['$state'];

        constructor(private $state: angular.ui.IStateService) {
            
        }
    }

    angular
        .module('budgetManager.transaction')
        .controller('transactionIndexController', TransactionIndexController);
}