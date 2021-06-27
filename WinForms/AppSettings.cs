using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WinForms
{
    public interface IAppSettings
    {
        string WebView2RuntimeFolder { get; }
        double InitLatitude { get; }
        double InitLongitude { get; }
        int InitZoom { get; }
    }

    public class AppSettings : IAppSettings
    {
        public AppSettings(IConfiguration configuration)
        {
            configuration.GetSection(nameof(AppSettings))
                .Bind(this);
        }

        public string WebView2RuntimeFolder { get; set; }
        public double InitLatitude { get; set; }
        public double InitLongitude { get; set; }
        public int InitZoom { get; set; }
    }
}
