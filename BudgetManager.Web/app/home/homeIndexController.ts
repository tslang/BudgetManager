module BudgetManager.Home {
    'use strict';

    export interface IHomeIndexController {
        title: string;
    }

    export class HomeIndexController implements IHomeIndexController {
        title: string = "Home View";

        public static $inject: string[] = ['$state'];

        constructor(private $state: angular.ui.IStateService) {
        }
    }

    angular
        .module('budgetManager.home')
        .controller('homeIndexController', HomeIndexController);
}