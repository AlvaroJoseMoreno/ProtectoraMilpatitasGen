﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebProtectoraMilpatitas.Startup))]
namespace WebProtectoraMilpatitas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
