module BudgetManager.Account {
    'use strict';

    export interface IAccountService {
        getAll(): angular.IHttpPromise<any>;
        getDetail(id: number): angular.IHttpPromise<any>;
        create(accountAddCommandModel: IAccountCreateCommandModel): angular.IHttpPromise<any>;
        edit(accountUpdateCommandModel: IAccountEditCommandModel): angular.IHttpPromise<any>;
    }

    export class AccountService implements IAccountService {
        public static $inject: string[] = ['dataServiceHelper', '$q'];

        constructor(private dataServiceHelper: Core.IDataServiceHelper,
            private $q: angular.IQService) {
        }

        public getAll(): angular.IHttpPromise<any> {
            return this.dataServiceHelper.get(Account.AccountUrls.all);
        }

        public getDetail(id: number): angular.IHttpPromise<any> {
            return this.dataServiceHelper.get(Account.AccountUrls.details);
        }

        public create(accountCreateCommandModel: IAccountCreateCommandModel): angular.IHttpPromise<any> {
            return this.dataServiceHelper.postWithParameters(Account.AccountUrls.create, accountCreateCommandModel);
        }

        public edit(accountEditCommandModel: any): angular.IHttpPromise<any> {
            return this.dataServiceHelper.postWithParameters(Account.AccountUrls.edit, accountEditCommandModel);
        }
    }

    angular.module('budgetManager.account')
        .service('accountService', AccountService);
}