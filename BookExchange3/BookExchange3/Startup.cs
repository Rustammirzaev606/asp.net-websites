using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookExchange3.Startup))]
namespace BookExchange3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
