using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agat.Startup))]
namespace Agat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
