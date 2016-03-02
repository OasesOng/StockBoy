using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StockBoy.Startup))]
namespace StockBoy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
