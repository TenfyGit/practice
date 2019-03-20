using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyQuartz.JobExecute.Startup))]
namespace MyQuartz.JobExecute
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
