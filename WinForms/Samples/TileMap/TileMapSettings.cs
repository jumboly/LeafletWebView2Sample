using Microsoft.Extensions.Configuration;

namespace WinForms.Samples.TileMap
{
    public interface ITileMapSettings
    {
        string UrlTemplate { get; }
        string Attribution { get; }
        int MinZoom { get; }
        int MaxZoom { get; }
    }

    public class TileMapSettings : ITileMapSettings
    {
        public TileMapSettings(IConfiguration configuration)
        {
            configuration.GetSection(nameof(TileMapSettings)).Bind(this);
        }

        public string UrlTemplate { get; set; }
        public string Attribution { get; set; }
        public int MinZoom { get; set; }
        public int MaxZoom { get; set; }
    }
}
