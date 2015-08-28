namespace LastFMStudio
{
    partial class SearchSkip
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
            this.search = new System.Windows.Forms.Button();
            this.skip = new System.Windows.Forms.Button();
            this.artist = new System.Windows.Forms.TextBox();
            this.album = new System.Windows.Forms.TextBox();
            this.track = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.search.Location = new System.Drawing.Point(36, 221);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 0;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // skip
            // 
            this.skip.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.skip.Location = new System.Drawing.Point(145, 221);
            this.skip.Name = "skip";
            this.skip.Size = new System.Drawing.Size(75, 23);
            this.skip.TabIndex = 1;
            this.skip.Text = "Skip";
            this.skip.UseVisualStyleBackColor = true;
            this.skip.Click += new System.EventHandler(this.skip_Click);
            // 
            // artist
            // 
            this.artist.Location = new System.Drawing.Point(36, 32);
            this.artist.Name = "artist";
            this.artist.Size = new System.Drawing.Size(184, 20);
            this.artist.TabIndex = 2;
            // 
            // album
            // 
            this.album.Location = new System.Drawing.Point(36, 80);
            this.album.Name = "album";
            this.album.Size = new System.Drawing.Size(184, 20);
            this.album.TabIndex = 3;
            // 
            // track
            // 
            this.track.Location = new System.Drawing.Point(36, 130);
            this.track.Name = "track";
            this.track.Size = new System.Drawing.Size(184, 20);
            this.track.TabIndex = 4;
            // 
            // SearchSkip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 261);
            this.Controls.Add(this.track);
            this.Controls.Add(this.album);
            this.Controls.Add(this.artist);
            this.Controls.Add(this.skip);
            this.Controls.Add(this.search);
            this.Name = "SearchSkip";
            this.Text = "SearchSkip";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button skip;
        private System.Windows.Forms.TextBox artist;
        private System.Windows.Forms.TextBox album;
        private System.Windows.Forms.TextBox track;
    }
}