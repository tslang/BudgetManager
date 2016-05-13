module BudgetManager {
    'use strict';

    angular.module('budgetManager', [
        'core',
        'ui.router',
        'budgetManager.home',
        'budgetManager.account',
        'budgetManager.budget',
        'budgetManager.transaction'
    ]);
}