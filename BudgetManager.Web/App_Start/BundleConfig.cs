using System.Web.Optimization;

namespace BudgetManager.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate*")
                );

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*")
                );

            bundles.Add(new ScriptBundle("~/bundles/angularJS")
                .Include("~/bower_components/angular/angular.js")
                .Include("~/bower_components/angular-ui-router/release/angular-ui-router.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/respond.js")
                );

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/site.css")
                );

            bundles.Add(new ScriptBundle("~/bundles/BudgetManager")
                .Include("~/app/core/core.module.js")
                .Include("~/app/core/forms.service.js")
                .Include("~/app/core/coreToast.service.js")
                .Include("~/app/core/urlHelper.service.js")
                .Include("~/app/core/dataServiceHelper.service.js")
                .Include("~/app/budgetManager/budgetManager.module.js")
                .Include("~/app/budgetManager/budgetManager.routes.js")
                .Include("~/app/budgetManager/home/home.module.js")
                .Include("~/app/budgetManager/account/account.module.js")
                .Include("~/app/budgetManager/account/account.constant.js")
                .Include("~/app/budgetManager/budget/budget.module.js")
                .Include("~/app/budgetManager/transaction/transaction.module.js")
                .Include("~/app/budgetManager/transaction/transaction.constant.js")
                .Include("~/app/budgetManager/home/homeIndexController.js")
                .Include("~/app/budgetManager/account/account.service.js")
                .Include("~/app/budgetManager/account/accountIndexController.js")
                .Include("~/app/budgetManager/account/accountDetailsController.js")
                .Include("~/app/budgetManager/account/accountCreateController.js")
                .Include("~/app/budgetManager/account/accountEditController.js")
                .Include("~/app/budgetManager/budget/budgetIndexController.js")
                .Include("~/app/budgetManager/transaction/transaction.service.js")
                .Include("~/app/budgetManager/transaction/transactionIndexController.js")
                );
        }
    }
}