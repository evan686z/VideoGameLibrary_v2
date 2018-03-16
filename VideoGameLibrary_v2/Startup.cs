using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoGameLibrary_v2.Startup))]
namespace VideoGameLibrary_v2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
