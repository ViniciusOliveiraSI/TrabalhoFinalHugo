using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fazenda.MVC.Startup))]
namespace Fazenda.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
