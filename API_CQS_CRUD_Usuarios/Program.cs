using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace API_CQS_CRUD_Usuarios
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
