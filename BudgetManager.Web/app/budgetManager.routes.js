var BudgetManager;
(function (BudgetManager) {
    'use strict';
    var RouteConfig = (function () {
        function RouteConfig($stateProvider, $urlRouterProvider, $locationProvider) {
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
        RouteConfig.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];
        return RouteConfig;
    })();
    angular.module("budgetManager")
        .config(RouteConfig);
})(BudgetManager || (BudgetManager = {}));
