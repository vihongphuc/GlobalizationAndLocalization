using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(localizationNGlobalizationSample_02.Startup))]
namespace localizationNGlobalizationSample_02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
