var BudgetManager;
(function (BudgetManager) {
    'use strict';
    angular.module('budgetManager', [
        'ui.router',
        'budgetManager.home',
        'budgetManager.account',
        'budgetManager.budget',
        'budgetManager.transaction'
    ]);
})(BudgetManager || (BudgetManager = {}));
