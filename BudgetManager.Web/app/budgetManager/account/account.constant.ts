module BudgetManager.Account {
    'use strict';

    export class AccountUrls {
        public static details: string = '/api/Account/Get/';
        public static create: string = '/api/Account/Add/';
        public static update: string = '/api/Account/Update/';
        public static all: string = '/api/Account/GetAll/';
    }
}