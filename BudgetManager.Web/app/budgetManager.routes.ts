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
                templateUrl: '/app/account/accountIndex.html',
                controller: 'accountIndexController as vm',
                data: { pageTitle: 'Accounts' }
            });
        }
    }

    angular.module('budgetManager').config(RouteConfig);
}