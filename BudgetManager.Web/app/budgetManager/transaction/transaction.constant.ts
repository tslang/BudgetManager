module BudgetManager.Transaction {
    'use strict';

    export class TransactionUrls {
        public static details: string = '/api/Transaction/Get';
        public static create: string = '/api/Transaction/Add';
        public static update: string = '/api/Transaction/Update';
        public static all: string = '/api/Transaction/GetAll';
    }
}