module Core {
    'use strict';

    angular.module('core',
        [
            'ngSanitize',
            'ngAnimate',
            'toastr'
        ]);

        class ToastrConfig {
            public static $inject: string[] = ['toastrConfig'];

            constructor(toastrConfig: any) {
                angular.extend(toastrConfig, {
                    timeOut:2500,
                    positionClass: 'toast-bottom-right',
                    progressBar: true
                });
            }
    }

        angular.module('core')
            .config(ToastrConfig);
}