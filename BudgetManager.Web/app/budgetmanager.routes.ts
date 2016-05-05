module BudgetManager {
    'use strict';

    class RouteConfig {
        public static $inject: string[] = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];

        constructor($stateProvider: angular.ui.IStateProvider,
            $urlRouterProvider: angular.ui.IUrlRouterProvider,
            $locationProvider: angular.ILocationProvider) {

            $urlRouterProvider.otherwise('/');

            $stateProvider.state('homeIndex', {
                url: '/',
                templateUrl: '/app/home/homeIndex.html',
                controller: 'homeIndexController as vm',
                data: { pageTitle: 'Home' }
            });
            $stateProvider.state('accountIndex', {
                url: '/Accounts',
                templateUrl: 'app/account/accountIndex.html',
                controller: 'accountIndexController as vm',
                data: { pageTitle: 'Account' }
            });
            $stateProvider.state('budgetIndex', {
                url: '/Budget',
                templateUrl: '/app/budget/budgetIndex.html',
                controller: 'budgetIndexController as vm',
                data: { pageTitle: 'Budget' }
            });
            $stateProvider.state('transactionIndex', {
                url: '/Transactions',
                templateUrl: '/app/transaction/transactionIndex.html',
                controller: 'transactionIndexController as vm',
                data: { pageTitle: 'Transactions' }
            });
        }
    }

    angular.module("budgetManager")
        .config(RouteConfig);
}