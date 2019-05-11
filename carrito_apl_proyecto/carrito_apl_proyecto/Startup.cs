using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(carrito_apl_proyecto.Startup))]
namespace carrito_apl_proyecto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
