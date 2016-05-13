namespace Core {
    'use strict';

    export interface ICoreToast {
        success(message: string, data: string, title: string): void;
        error(message: string, data: string, title: string): void;
        info(message: string, data: string, title: string): void;
        warning(message: string, data: string, title: string): void;
    }

    export class CoreToast implements ICoreToast {
        public static $inject: string[] = ['toastr'];

        constructor(private toastr: ng.toastr.IToastrService) {
        }

        public success(message: string, data: string, title: string): void {
            this.toastr.success(message, title);
        }

        public error(message: string, data: string, title: string): void {
            this.toastr.error(message, title);
        }

        public info(message: string, data: string, title: string): void {
            this.toastr.info(message, title);
        }
        public warning(message: string, data: string, title: string): void {
            this.toastr.warning(message, title);
        }
    }

    angular.module('core')
        .service('coreToast', CoreToast);
}