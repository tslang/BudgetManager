var BudgetManager;
(function (BudgetManager) {
    var Home;
    (function (Home) {
        'use strict';
        var HomeIndexController = (function () {
            function HomeIndexController($state) {
                this.$state = $state;
                this.title = "Home View";
            }
            HomeIndexController.$inject = ['$state'];
            return HomeIndexController;
        })();
        Home.HomeIndexController = HomeIndexController;
        angular
            .module('budgetManager.home')
            .controller('homeIndexController', HomeIndexController);
    })(Home = BudgetManager.Home || (BudgetManager.Home = {}));
})(BudgetManager || (BudgetManager = {}));
