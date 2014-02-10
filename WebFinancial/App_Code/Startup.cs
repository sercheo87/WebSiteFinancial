using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFinancial.Startup))]
namespace WebFinancial
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
