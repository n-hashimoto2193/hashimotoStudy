using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KintaiKanri.Startup))]
namespace KintaiKanri
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
