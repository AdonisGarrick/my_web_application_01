using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASM_02.Startup))]
namespace ASM_02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
