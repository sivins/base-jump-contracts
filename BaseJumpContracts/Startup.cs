using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BaseJumpContracts.Startup))]
namespace BaseJumpContracts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
