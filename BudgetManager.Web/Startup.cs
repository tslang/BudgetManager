using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BudgetManager.Web.Startup))]
namespace BudgetManager.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
