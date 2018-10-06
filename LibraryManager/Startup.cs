using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryManager.Startup))]
namespace LibraryManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
