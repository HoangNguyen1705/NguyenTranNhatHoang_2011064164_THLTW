using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NguyenTranNhatHoang_2011064164_THLTW.Startup))]
namespace NguyenTranNhatHoang_2011064164_THLTW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
