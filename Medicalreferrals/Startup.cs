using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Medicalreferrals.Startup))]
namespace Medicalreferrals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
