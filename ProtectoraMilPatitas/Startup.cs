using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProtectoraMilPatitas.Startup))]
namespace ProtectoraMilPatitas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
