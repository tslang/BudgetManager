var BudgetManager;
(function (BudgetManager) {
    var Budget;
    (function (Budget) {
        'use strict';
        var BudgetIndexController = (function () {
            function BudgetIndexController($state) {
                this.$state = $state;
                this.title = "Budget View";
            }
            BudgetIndexController.$inject = ['$state'];
            return BudgetIndexController;
        })();
        Budget.BudgetIndexController = BudgetIndexController;
        angular
            .module('budgetManager.budget')
            .controller('budgetIndexController', BudgetIndexController);
    })(Budget = BudgetManager.Budget || (BudgetManager.Budget = {}));
})(BudgetManager || (BudgetManager = {}));
