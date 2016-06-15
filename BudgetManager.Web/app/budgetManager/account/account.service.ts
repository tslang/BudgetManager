module BudgetManager.Account {
    'use strict';

    export interface IAccountService {
        getAll(): angular.IHttpPromise<any>;
        getDetails(id: number): angular.IHttpPromise<any>;
        create(accountAddCommandModel: IAccountCreateEditCommandModel): angular.IHttpPromise<any>;
        edit(accountUpdateCommandModel: IAccountCreateEditCommandModel): angular.IHttpPromise<any>;
    }

    export class AccountService implements IAccountService {
        public static $inject: string[] = ['dataServiceHelper', '$q'];

        constructor(private dataServiceHelper: Core.IDataServiceHelper,
            private $q: angular.IQService) {
        }

        public getAll(): angular.IHttpPromise<any> {
            return this.dataServiceHelper.get(Account.AccountUrls.all);
        }

        public getDetails(id: number): angular.IPromise<any> {
            return this.dataServiceHelper.getWithKey(AccountUrls.details, id);
        }

        public create(accountCreateEditCommandModel: IAccountCreateEditCommandModel): angular.IHttpPromise<any> {
            return this.dataServiceHelper.postWithParameters(Account.AccountUrls.create, accountCreateEditCommandModel);
        }

        public edit(accountCreateEditCommandModel: any): angular.IHttpPromise<any> {
            return this.dataServiceHelper.postWithParameters(Account.AccountUrls.edit, accountCreateEditCommandModel);
        }
    }

    angular.module('budgetManager.account')
        .service('accountService', AccountService);
}