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
                templateUrl: '/app/budgetManager/home/homeIndex.html',
                controller: 'homeIndexController as vm',
                data: { pageTitle: 'Home' }
            });
            $stateProvider.state('accountIndex', {
                url: '/Accounts',
                templateUrl: '/app/budgetManager/account/accountIndex.html',
                controller: 'accountIndexController as vm',
                data: { pageTitle: 'Accounts' }
            });
            $stateProvider.state('accountDetails', {
                url: '/Account/Details/:id',
                templateUrl: '/app/budgetManager/account/accountDetails.html',
                controller: 'accountDetailsController as vm',
            data: { pageTitle: 'Account Details'}
            });
            $stateProvider.state('budgetIndex', {
                url: '/Budget',
                templateUrl: '/app/budgetManager/budget/budgetIndex.html',
                controller: 'budgetIndexController as vm',
                data: { pageTitle: 'Budget' }
            });
            $stateProvider.state('transactionIndex', {
                url: '/Transactions',
                templateUrl: '/app/budgetManager/transaction/transactionIndex.html',
                controller: 'transactionIndexController as vm',
                data: { pageTitle: 'Transactions' }
            });
        }
    }

    angular.module('budgetManager').config(RouteConfig);
}