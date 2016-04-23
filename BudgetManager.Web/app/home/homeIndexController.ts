module BudgetManager.Home {
    'use strict';

    export interface IHomeIndexController {
        
    }

    export class HomeIndexController implements IHomeIndexController {
        
        public title: string = 'Home';
        
        public static $inject: string[] = ['$state'];

        constructor(private $state: angular.ui.IStateService) {
            
        }
    }


    angular
        .module('budgetmanager.home')
        .controller('homeIndexController', HomeIndexController);

}