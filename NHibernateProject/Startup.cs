using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NHibernateProject.Startup))]
namespace NHibernateProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
