using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace WinForms.Samples.TileMap
{
    public partial class TileMapForm : Form
    {
        private readonly IAppSettings _appSettings;
        private readonly ITileMapSettings _tileMapSettings;

        public TileMapForm(IAppSettings appSettings, ITileMapSettings tileMapSettings)
        {
            _appSettings = appSettings;
            _tileMapSettings = tileMapSettings;

            InitializeComponent();
        }

        private async void TileMapForm_Load(object sender, System.EventArgs e)
        {
            Enabled = false;

            await InitMapAsync();

            Enabled = true;
        }

        private async Task InitMapAsync()
        {
            // ランタイム設定
            await webView.EnsureRuntime(_appSettings.WebView2RuntimeFolder);

            // HTML読み込み: ここで指定するHTMLファイルの「出力ディレクトリにコピー」を「新しい場合はコピー」にしておく
            await webView.LoadHtmlAsync(@"Samples\TileMap\TileMap.html");

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
                center = new[] {_appSettings.InitLatitude, _appSettings.InitLongitude},
                zoom = _appSettings.InitZoom,
            });
        }
    }
}
