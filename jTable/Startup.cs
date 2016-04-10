using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jTable.Startup))]
namespace jTable
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
