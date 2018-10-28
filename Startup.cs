using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudyPoints.Startup))]
namespace StudyPoints
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
