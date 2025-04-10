using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetCareSystem.Startup))]
namespace PetCareSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
