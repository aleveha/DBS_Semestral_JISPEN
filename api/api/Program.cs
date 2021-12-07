using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace api {
    public class Program {
        public static void Main(string[] args) {
            IHost host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}
