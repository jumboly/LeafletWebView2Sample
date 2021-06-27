using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using WinForms.Samples.TileMap;

namespace WinForms.Samples.GeoJSON
{
    public partial class GeoJSONForm : Form
    {
        private readonly IAppSettings _appSettings;
        private readonly ITileMapSettings _tileMapSettings;

        private readonly GeoJsonReader _reader = new();
        private readonly GeoJsonWriter _writer = new();

        public GeoJSONForm(IAppSettings appSettings, ITileMapSettings tileMapSettings)
        {
            _appSettings = appSettings;
            _tileMapSettings = tileMapSettings;
            InitializeComponent();
        }

        private async void GeoJSONForm_Load(object sender, EventArgs e)
        {
            Enabled = false;
            
            await InitMapAsync();

            // 初期位置のポイントをGeoJsonに
            var point = new NetTopologySuite.Geometries.Point(_appSettings.InitLongitude, _appSettings.InitLatitude);
            geoJsonTextBox.Text = _writer.Write(point);

            Enabled = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            // GeoJSONを表示
            webView.InvokeAsync("geoJSON", new {
                geojson = geoJsonTextBox.Text
            });
        }

        private async Task InitMapAsync()
        {
            // ランタイム設定
            await webView.EnsureRuntime(_appSettings.WebView2RuntimeFolder);

            // HTML読み込み: ここで指定するHTMLファイルの「出力ディレクトリにコピー」を「新しい場合はコピー」にしておく
            await webView.LoadHtmlAsync(@"Samples\GeoJSON\GeoJSON.html");

            // リンクは標準ブラウザで表示
            webView.NavigationStarting += (sender, args) => {
                args.Cancel = true;
                Process.Start(new ProcessStartInfo(args.Uri) {
                    UseShellExecute = true,
                });
            };

            // タイルレイヤ設定
            await webView.InvokeAsync("tileLayer", new {
                urlTemplate = _tileMapSettings.UrlTemplate,
                options = new {
                    attribution = _tileMapSettings.Attribution,
                    minZoom = _tileMapSettings.MinZoom,
                    maxZoom = _tileMapSettings.MaxZoom,
                },
            });

            // 初期位置表示
            await webView.InvokeAsync("setView", new {
                center = new[] { _appSettings.InitLatitude, _appSettings.InitLongitude },
                zoom = _appSettings.InitZoom,
            });
        }
    }
}
