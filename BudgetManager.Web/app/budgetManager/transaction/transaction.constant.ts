module BudgetManager.Transaction {
    'use strict';

    export class TransactionUrls {
        public static details: string = '/api/Transaction/Get';
        public static create: string = '/api/Transaction/Create';
        public static edit: string = '/api/Transaction/Edit';
        public static all: string = '/api/Transaction/GetAll';
    }
}