using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(localizationNGlobalizationSample_01.Startup))]
namespace localizationNGlobalizationSample_01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
