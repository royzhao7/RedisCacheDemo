using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedisCacheDemo.Startup))]
namespace RedisCacheDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
