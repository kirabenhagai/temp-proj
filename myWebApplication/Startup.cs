﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(myWebApplication.Startup))]
namespace myWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
