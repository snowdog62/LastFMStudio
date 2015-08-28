namespace LastFMStudio
{
    partial class LastFMStudio
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
            this.userBox = new System.Windows.Forms.TextBox();
            this.ExportLibrary = new System.Windows.Forms.Button();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.ExportScrobbles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.artistBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.albumBox = new System.Windows.Forms.TextBox();
            this.exportArtist = new System.Windows.Forms.Button();
            this.exportAlbum = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userBox
            // 
            this.userBox.Location = new System.Drawing.Point(13, 39);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(100, 20);
            this.userBox.TabIndex = 0;
            // 
            // ExportLibrary
            // 
            this.ExportLibrary.Location = new System.Drawing.Point(13, 96);
            this.ExportLibrary.Name = "ExportLibrary";
            this.ExportLibrary.Size = new System.Drawing.Size(100, 23);
            this.ExportLibrary.TabIndex = 1;
            this.ExportLibrary.Text = "Export Library";
            this.ExportLibrary.UseVisualStyleBackColor = true;
            this.ExportLibrary.Click += new System.EventHandler(this.ExportLibrary_Click);
            // 
            // startDate
            // 
            this.startDate.AllowDrop = true;
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(52, 194);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(145, 20);
            this.startDate.TabIndex = 2;
            // 
            // ExportScrobbles
            // 
            this.ExportScrobbles.Location = new System.Drawing.Point(52, 257);
            this.ExportScrobbles.Name = "ExportScrobbles";
            this.ExportScrobbles.Size = new System.Drawing.Size(113, 23);
            this.ExportScrobbles.TabIndex = 4;
            this.ExportScrobbles.Text = "Export Scrobbles";
            this.ExportScrobbles.UseVisualStyleBackColor = true;
            this.ExportScrobbles.Click += new System.EventHandler(this.ExportScrobbles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Artist";
            // 
            // artistBox
            // 
            this.artistBox.Location = new System.Drawing.Point(151, 39);
            this.artistBox.Name = "artistBox";
            this.artistBox.Size = new System.Drawing.Size(100, 20);
            this.artistBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Album";
            // 
            // albumBox
            // 
            this.albumBox.Location = new System.Drawing.Point(271, 39);
            this.albumBox.Name = "albumBox";
            this.albumBox.Size = new System.Drawing.Size(100, 20);
            this.albumBox.TabIndex = 8;
            // 
            // exportArtist
            // 
            this.exportArtist.Location = new System.Drawing.Point(151, 96);
            this.exportArtist.Name = "exportArtist";
            this.exportArtist.Size = new System.Drawing.Size(100, 23);
            this.exportArtist.TabIndex = 10;
            this.exportArtist.Text = "Export Artist";
            this.exportArtist.UseVisualStyleBackColor = true;
            this.exportArtist.Click += new System.EventHandler(this.exportArtist_Click);
            // 
            // exportAlbum
            // 
            this.exportAlbum.Location = new System.Drawing.Point(271, 96);
            this.exportAlbum.Name = "exportAlbum";
            this.exportAlbum.Size = new System.Drawing.Size(100, 23);
            this.exportAlbum.TabIndex = 11;
            this.exportAlbum.Text = "Export Album";
            this.exportAlbum.UseVisualStyleBackColor = true;
            this.exportAlbum.Click += new System.EventHandler(this.exportAlbum_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(203, 135);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(186, 145);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(178, 119);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LastFMStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 301);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.exportAlbum);
            this.Controls.Add(this.exportArtist);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.albumBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.artistBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExportScrobbles);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.ExportLibrary);
            this.Controls.Add(this.userBox);
            this.Name = "LastFMStudio";
            this.Text = "LastFMStudio";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.Button ExportLibrary;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Button ExportScrobbles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox artistBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox albumBox;
        private System.Windows.Forms.Button exportArtist;
        private System.Windows.Forms.Button exportAlbum;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

