using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VkazoMaterial.Startup))]
namespace VkazoMaterial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
