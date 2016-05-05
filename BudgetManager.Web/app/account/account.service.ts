module BudgetManager.Account {
    'use strict';

    export interface IAccountService {
        getAll(): angular.IPromise<any>;
        getDetail(id: number): angular.IPromise<any>;
    }
}