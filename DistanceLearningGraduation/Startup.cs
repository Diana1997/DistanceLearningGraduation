using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DistanceLearningGraduation.Startup))]
namespace DistanceLearningGraduation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
