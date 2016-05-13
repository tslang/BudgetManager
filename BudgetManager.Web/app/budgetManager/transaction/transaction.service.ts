module BudgetManager.Transaction {
    'use strict';

    export interface ITransactionService {
        getAll(): angular.IHttpPromise<any>;
        getDetails(): angular.IHttpPromise<any>;
        add(transactionAddCommandModel: any): angular.IHttpPromise<any>;
        update(transactionUpdateCommandModel: any): angular.IHttpPromise<any>;
    }

    export class TransactionService implements ITransactionService {
        public static $inject = ['dataServiceHelper'];

        constructor(private dataServiceHelper: Core.IDataServiceHelper) {
            
        }

        public getAll(): angular.IHttpPromise<any> {
            return this.dataServiceHelper.get(Transaction.TransactionUrls.all);
        }

        public getDetails(): angular.IHttpPromise<any> {
            return this.dataServiceHelper.get(Transaction.TransactionUrls.details);
        }

        public add(transactionAddCommandModel: any): angular.IHttpPromise<any> {
            return this.dataServiceHelper.postWithParameters(Transaction.TransactionUrls.create, {
                model: transactionAddCommandModel
            });
        }

        public update(transactionUpdateCommandModel: any): angular.IHttpPromise<any> {
            return this.dataServiceHelper.postWithParameters(Transaction.TransactionUrls.update, {
                model: transactionUpdateCommandModel
            });
        }
    }

    angular.module('budgetManager.transaction')
        .service('transactionService', TransactionService);
}