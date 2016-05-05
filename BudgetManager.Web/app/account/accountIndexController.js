var BudgetManager;
(function (BudgetManager) {
    var Account;
    (function (Account) {
        'use strict';
        var AccountIndexController = (function () {
            function AccountIndexController($state) {
                this.$state = $state;
                this.title = "Account View";
            }
            AccountIndexController.$inject = ['$state'];
            return AccountIndexController;
        })();
        Account.AccountIndexController = AccountIndexController;
        angular
            .module('budgetManager.account')
            .controller('accountIndexController', AccountIndexController);
    })(Account = BudgetManager.Account || (BudgetManager.Account = {}));
})(BudgetManager || (BudgetManager = {}));
