using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AGLTest.Startup))]
namespace AGLTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
