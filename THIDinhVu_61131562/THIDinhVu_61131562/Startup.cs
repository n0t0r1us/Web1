using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(THIDinhVu_61131562.Startup))]
namespace THIDinhVu_61131562
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
