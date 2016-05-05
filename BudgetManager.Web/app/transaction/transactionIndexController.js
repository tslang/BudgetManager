var BudgetManager;
(function (BudgetManager) {
    var Transaction;
    (function (Transaction) {
        'use strict';
        var TransactionIndexController = (function () {
            function TransactionIndexController($state) {
                this.$state = $state;
                this.title = "Transaction View";
            }
            TransactionIndexController.$inject = ['$state'];
            return TransactionIndexController;
        })();
        Transaction.TransactionIndexController = TransactionIndexController;
        angular
            .module('budgetManager.transaction')
            .controller('transactionIndexController', TransactionIndexController);
    })(Transaction = BudgetManager.Transaction || (BudgetManager.Transaction = {}));
})(BudgetManager || (BudgetManager = {}));
