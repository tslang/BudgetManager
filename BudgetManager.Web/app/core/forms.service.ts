namespace Core {
    'use strict';

    export interface IModelState {
        [field: string]: string[];
    }

    export interface ICoreFormsService {
        parseErrorMessagesFromModelStateErrorResponse(response: any): string[];
        setRequiredFieldsDirty(form: angular.IFormController): void;
        convertDateStringToDate(date: any): Date;
    }

    export class CoreFormsService implements ICoreFormsService {
        public parseErrorMessagesFromModelStateErrorResponse(response: angular.IHttpPromiseCallbackArg<any>): string[] {
            // we're getting the whole response here, so we expect that if the data attribute
            // is blank then we got a major top level error (500, 404, etc).  If so, then we just return
            // that message.  If the data attribute is NOT blank, we expect to get model state errors
            // so cast them into our IModelState interface, loop through and show them.

            if (response.data) {
                if (response.data.ModelState) {
                    return this.parseMessages(response.data.ModelState);
                } else if (angular.isString(response.data) === true) {
                    return [response.data];
                }
            } else if (angular.isString(response.statusText) === true) {
                return [response.statusText];
            }

            return [];
        }

        /**
         * Set the $dirty flag on each form field that has a required validator. will also set the $dirty flag at the form level if any required validators exist
         *
         * @param form Form to scan for required field validators on
         * @link http://stackoverflow.com/a/27503205/3745837
         */
        public setRequiredFieldsDirty(form: angular.IFormController): void {
            angular.forEach(form.$error.required, (field: any) => {
                field.$setDirty();
            });

            angular.forEach(form.$error.objectRequired, (field: any) => {
                field.$setDirty();
            });
        }

        public convertDateStringToDate(value: any): Date {
            if (angular.isDate(value) === true) {
                return value;
            }

            if (typeof value === 'string') {
                //  TODO    make regex validate that the HOURS are between 0 and 23
                if (value.match(/^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2]\d|3[0-1])T([0,1]\d|2[0-3])(:[0-5]\d){2}(\.\d{3,7})?$/)) {   //  regex figured out by Tomeh
                    return new Date(value);
                }
            }

            return null;
        }

        private parseMessages(modelState: IModelState): string[] {
            var messages: string[] = [];
            for (var field in modelState) {
                if (modelState.hasOwnProperty(field)) {
                    for (var i: number = 0; i < modelState[field].length; i++) {
                        messages.push(modelState[field][i]);
                    }
                }
            }
            return messages;
        }
    }

    angular.module('core')
        .service('coreFormsService', CoreFormsService);
}