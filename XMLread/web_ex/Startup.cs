using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(web_ex.Startup))]
namespace web_ex
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
