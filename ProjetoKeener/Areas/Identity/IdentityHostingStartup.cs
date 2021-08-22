using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(WebApplication2.Areas.Identity.IdentityHostingStartup))]
namespace WebApplication2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                //services.adddefaultidentity<webapplication2user>(options =>
                //{
                //    options.signin.requireconfirmedaccount = false;
                //    options.password.requirelowercase = false;
                //    options.password.requireuppercase = false;
                //})
                //.addentityframeworkstores<sqlcontext>();

            });
        }
    }
}