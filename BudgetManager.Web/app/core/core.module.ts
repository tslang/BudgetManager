module Core {
    'use strict';

    angular.module('core',
        [
            'ui.router',
            'core',
            'budgetManager.home',
            'budgetManager.account',
            'budgetManager.budget',
            'budgetManager.transaction'
        ]);
}