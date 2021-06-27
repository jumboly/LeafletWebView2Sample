
namespace WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tileMapButton = new System.Windows.Forms.Button();
            this.geoJsonButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tileMapButton
            // 
            this.tileMapButton.Location = new System.Drawing.Point(12, 12);
            this.tileMapButton.Name = "tileMapButton";
            this.tileMapButton.Size = new System.Drawing.Size(132, 38);
            this.tileMapButton.TabIndex = 0;
            this.tileMapButton.Text = "タイルマップ";
            this.tileMapButton.UseVisualStyleBackColor = true;
            this.tileMapButton.Click += new System.EventHandler(this.tileMapButton_Click);
            // 
            // geoJsonButton
            // 
            this.geoJsonButton.Location = new System.Drawing.Point(12, 68);
            this.geoJsonButton.Name = "geoJsonButton";
            this.geoJsonButton.Size = new System.Drawing.Size(132, 38);
            this.geoJsonButton.TabIndex = 1;
            this.geoJsonButton.Text = "GeoJSON";
            this.geoJsonButton.UseVisualStyleBackColor = true;
            this.geoJsonButton.Click += new System.EventHandler(this.geoJsonButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.geoJsonButton);
            this.Controls.Add(this.tileMapButton);
            this.Name = "MainForm";
            this.Text = "Leafletサンプル";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tileMapButton;
        private System.Windows.Forms.Button geoJsonButton;
    }
}

