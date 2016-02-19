using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WoMU_lab2.Startup))]
namespace WoMU_lab2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
