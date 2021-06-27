using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

// ReSharper disable once CheckNamespace
namespace Microsoft.Web.WebView2.WinForms
{
    public static class WebView2CoreExtensions
    {
        // ランタイムを初期化
        public static async Task EnsureRuntime(this WebView2 webView2, string runtimeFolder = default)
        {
            if (runtimeFolder != default && !Path.IsPathRooted(runtimeFolder))
            {
                runtimeFolder = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), runtimeFolder);
            }
            var environment = await CoreWebView2Environment.CreateAsync(runtimeFolder).ConfigureAwait(false);
            await webView2.EnsureCoreWebView2Async(environment).ConfigureAwait(false);
        }

        // HTMLファイルをロード
        public static Task LoadHtmlAsync(this WebView2 webView, string htmlPath)
        {
            if (!Path.IsPathRooted(htmlPath))
            {
                htmlPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), htmlPath);
            }
            htmlPath = htmlPath.Replace('\\', '/');

            var tcs = new TaskCompletionSource();

            webView.NavigationCompleted += NavigationCompleted;
            webView.Source = new Uri($"file:///{htmlPath}");

            return tcs.Task;

            void NavigationCompleted(object sender, Core.CoreWebView2NavigationCompletedEventArgs e)
            {
                webView.NavigationCompleted -= NavigationCompleted;
                tcs.SetResult();
            }
        }

        // Javascript 関数実行
        public static Task<string> InvokeAsync(this WebView2 webView, string function, object args)
        {
            return webView.ExecuteScriptAsync($"{function}({JsonSerializer.Serialize(args)})");
        }

        // Javascript 関数実行 (戻り値をJSONとしてデシリアライズ)
        public static async Task<T> InvokeAsync<T>(this WebView2 webView, string function, object args)
        {
            var ret = await webView.InvokeAsync(function, args).ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(ret);
        }
    }
}
