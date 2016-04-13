using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BudgetManager.Startup))]
namespace BudgetManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
