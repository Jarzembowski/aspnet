using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Validate.Startup))]
namespace Validate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
