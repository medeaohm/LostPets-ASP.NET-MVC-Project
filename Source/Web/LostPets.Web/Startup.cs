using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(LostPets.Web.Startup))]

namespace LostPets.Web
{
    /// <summary>
    /// Partial Class StartUp
    /// </summary>
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
