using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TATA_BANK.Startup))]
namespace TATA_BANK
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
