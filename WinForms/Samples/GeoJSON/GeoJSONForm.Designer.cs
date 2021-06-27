
namespace WinForms.Samples.GeoJSON
{
    partial class GeoJSONForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.button = new System.Windows.Forms.Button();
            this.geoJsonTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Location = new System.Drawing.Point(396, 41);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(392, 397);
            this.webView.TabIndex = 0;
            this.webView.ZoomFactor = 1D;
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(12, 12);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 1;
            this.button.Text = "表示";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // geoJsonTextBox
            // 
            this.geoJsonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.geoJsonTextBox.Location = new System.Drawing.Point(12, 41);
            this.geoJsonTextBox.Multiline = true;
            this.geoJsonTextBox.Name = "geoJsonTextBox";
            this.geoJsonTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.geoJsonTextBox.Size = new System.Drawing.Size(378, 397);
            this.geoJsonTextBox.TabIndex = 2;
            // 
            // GeoJSONForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.geoJsonTextBox);
            this.Controls.Add(this.button);
            this.Controls.Add(this.webView);
            this.Name = "GeoJSONForm";
            this.Text = "GeoJSON";
            this.Load += new System.EventHandler(this.GeoJSONForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox geoJsonTextBox;
    }
}