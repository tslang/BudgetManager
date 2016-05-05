module BudgetManager.Budget {
    'use strict';

    export interface IBudgetIndexController {
        title: string;
    }

    export class BudgetIndexController implements IBudgetIndexController {
        public title: string = "Budget View";

        public static $inject: string[] = ['$state'];

        constructor(private $state: angular.ui.IStateService) {

        }
    }

    angular
        .module('budgetManager.budget')
        .controller('budgetIndexController', BudgetIndexController);
}