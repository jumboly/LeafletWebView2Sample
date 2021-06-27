using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using WinForms.Samples.GeoJSON;
using WinForms.Samples.TileMap;

namespace WinForms
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _provider;

        public MainForm(IServiceProvider provider)
        {
            _provider = provider;
            InitializeComponent();
        }

        private void tileMapButton_Click(object sender, EventArgs e)
        {
            ShowSample<TileMapForm>();
        }
        private void geoJsonButton_Click(object sender, EventArgs e)
        {
            ShowSample<GeoJSONForm>();
        }
        
        private void ShowSample<T>() where T : Form
        {
            using var form = _provider.GetService<T>();
            form.ShowDialog(this);
        }
    }
}
