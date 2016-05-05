module BudgetManager.Account {
    'use strict';

    export interface IAccountIndexController {
        title: string;
    }

    export class AccountIndexController implements IAccountIndexController {
        title: string = "Account View";

        public static $inject: string[] = ['$state'];

        constructor(private $state: angular.ui.IStateProvider) {
        }
    }

    angular
        .module('budgetManager.account')
        .controller('accountIndexController', AccountIndexController);
}