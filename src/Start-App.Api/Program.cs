// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Start_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
