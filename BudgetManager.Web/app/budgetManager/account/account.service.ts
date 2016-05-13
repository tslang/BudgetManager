module BudgetManager.Account {
    'use strict';

    export interface IAccountService {
        getAll(): angular.IHttpPromise<any>;
        getDetail(id: number): angular.IHttpPromise<any>;
        add(accountAddCommandModel: any): angular.IHttpPromise<any>;
        update(accountUpdateCommandModel: any): angular.IHttpPromise<any>;
    }

    export class AccountService implements IAccountService {
        public static $inject = ['dataServiceHelper'];

        constructor(private dataServiceHelper: Core.IDataServiceHelper) {
        }

        public getAll(): angular.IHttpPromise<any> {
            return this.dataServiceHelper.get(Account.AccountUrls.all);
        }

        public getDetail(id: number): angular.IHttpPromise<any> {
            return this.dataServiceHelper.get(Account.AccountUrls.details);
        }

        public add(accountAddCommandModel: any): angular.IHttpPromise<any> {
            return this.dataServiceHelper.postWithParameters(Account.AccountUrls.create, {
                model: accountAddCommandModel
            });
        }

        public update(accountUpdateCommandModel: any): angular.IHttpPromise<any> {
            return this.dataServiceHelper.postWithParameters(Account.AccountUrls.update, {
                model: accountUpdateCommandModel
            });
        }
    }

    angular.module('budgetManager.account')
        .service('accountService', AccountService);
}