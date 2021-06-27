using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleAppFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WinForms.Samples.GeoJSON;
using WinForms.Samples.TileMap;

namespace WinForms
{
    class Program : ConsoleAppBase
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
#if DEBUG
            args = new string[]
            {
                // "-formName", "TileMapForm"
                // "-formName", "GeoJSONForm"
            };
#endif
            Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .RunConsoleAppFrameworkAsync<Program>(args)
                .Wait();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAppSettings, AppSettings>();
            services.AddSingleton<ITileMapSettings, TileMapSettings>();

            services.AddTransient<TileMapForm>();
            services.AddTransient<GeoJSONForm>();
            services.AddTransient<MainForm>();
        }

        // ----------------------------------------------

        private readonly ILogger<Program> _logger;
        private readonly IServiceProvider _provider;

        public Program(ILogger<Program> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        public void Run(string formName = default)
        {
            Application.ThreadException += (sender, args) =>
            {
                _logger.LogError(args.Exception, "キャッチされない例外");
                MessageBox.Show(args.Exception.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form form = formName switch
            {
                nameof(TileMapForm) => _provider.GetService<TileMapForm>(),
                nameof(GeoJSONForm) => _provider.GetService<GeoJSONForm>(),
                _ => _provider.GetService<MainForm>(),
            };
            
            Application.Run(form);
        }
    }
}
