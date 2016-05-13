module Core {
    'use strict';

    export interface IDataServiceHelper {
        get(url: string): angular.IHttpPromise<any>;
        getWithKey(url: string, key: number): angular.IHttpPromise<any>;
        getWithStringKey(url: string, key: string): angular.IHttpPromise<any>;
        getWithQueryString(url: string, params: any): angular.IHttpPromise<any>;
        postWithParameters(url: string, params: any): angular.IHttpPromise<any>;
        postWithoutParameters(url: string): any;
    }

    export class DataServiceHelper implements IDataServiceHelper {
        public static $inject: string[] = ['$http', 'urlHelper'];

        constructor(private $http: angular.IHttpService,
                    private urlHelper: IUrlHelper) {
        }

        public get(url: string) {
            var fullUrl: string = this.urlHelper.removeTrailingSlashOnUrl(url);
            return this.$http.get(fullUrl);
        }

        public getWithKey(url: string, key: number) {
            var fullUrl: string = this.urlHelper.addTrailingSlashOnUrl(url) + key;
            return this.$http.get(fullUrl);
        }

        public getWithStringKey(url: string, key: string) {
            var fullUrl: string = this.urlHelper.addTrailingSlashOnUrl(url) + key;
            return this.$http.get(fullUrl);
        }

        public getWithQueryString<T>(url: string, params: T) {
            return this.$http.get(this.urlHelper.removeTrailingSlashOnUrl(url), { params: params });
        }

        public postWithParameters<T>(url: string, params: T) {
            return this.$http.post(this.urlHelper.removeTrailingSlashOnUrl(url), params);
        }

        public postWithoutParameters(url: string) {
            return this.$http.post(this.urlHelper.removeTrailingSlashOnUrl(url), {});
        }
    }

    angular.module('core')
        .service('dataServiceHelper', DataServiceHelper);

}