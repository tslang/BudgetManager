module BudgetManager {
    'use strict';

    angular.module('budgetManager', [
        'core',
        'ui.router',
        'ngSanitize',
        'ngAnimate',
        'ui.bootstrap',
        'budgetManager.home',
        'budgetManager.account',
        'budgetManager.budget',
        'budgetManager.transaction'
    ]);
}