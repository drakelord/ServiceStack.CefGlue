﻿using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;

namespace ServiceStack.CefGlue.Win64.AspNetCore
{
    class Program
    {
        static int Main(string[] args)
        {
            var startUrl = Environment.GetEnvironmentVariable("ASPNETCORE_URLS") ?? "http://localhost:5000/";

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseUrls(startUrl)
                .Build();

            var startTask = host.StartAsync();

            var config = new CefGlueConfig
            {
                Args = args,
                StartUrl = startUrl,
            };

            return CefPlatformWindows.Start(config);
        }
    }
}
