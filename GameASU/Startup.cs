using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameASU.Startup))]
namespace GameASU
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
