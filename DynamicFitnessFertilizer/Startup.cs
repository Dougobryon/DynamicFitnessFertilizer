using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DynamicFitnessFertilizer.Startup))]
namespace DynamicFitnessFertilizer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
