module BudgetManager {
    'use strict';

    angular.module("budgetmanager", [
        'ui.router',
        'budgetmanager.home',
        'budgetmanager.account',
        'budgetmanager.transaction'
    ]);

}