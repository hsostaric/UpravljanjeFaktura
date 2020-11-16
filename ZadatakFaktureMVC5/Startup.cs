using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZadatakFaktureMVC5.Startup))]
namespace ZadatakFaktureMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
