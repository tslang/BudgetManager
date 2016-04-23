module BudgetManager {
    "use strict";

    class RouteConfig {
        static $inject: string[] = ["$stateProvider", "$urlRouteProvider", "$locationProvider"];

        constructor($stateProvider: angular.ui.IStateProvider,
            $urlRouteProvider: angular.ui.IUrlRouterProvider,
            $locationProvider: angular.ILocationProvider) {

            $urlRouteProvider.otherwise('/');

            $stateProvider.state('homeIndex', {
                url: '/',
                templateUrl: '/app/home/homeIndex.html',
                controller: 'homeIndexController as vm',
                data: { pageTitle: 'Home' }
            });
            $stateProvider.state('accountsIndex', {
                url: '/Accounts',
                templateUrl: '/app/account/accountIndex.html',
                controller: 'accountIndexController as vm',
                data: { pageTitle: 'Index' }
            });
            $stateProvider.state('transactionsIndex', {
                url: '/Transactions',
                templateUrl: '/app/transaction/transactionIndex.html',
                controller: 'transactionIndexController as vm',
                data: { pageTitle: 'Index' }
            });
        }
    }

    angular.module('budgetmanager')
        .config(RouteConfig);
}