using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastFMStudio
{
    public partial class SearchSkip : Form
    {
        public string userArtist { get; private set; }
        public string userAlbum { get; private set; }
        public string userTrack { get; private set; }

        public SearchSkip(string art, string alb, string tra)
        {
            InitializeComponent();
            artist.Text = art;
            album.Text = alb;
            track.Text = tra;
        }

        private void search_Click(object sender, EventArgs e)
        {

            userArtist = this.artist.Text;
            userAlbum = this.album.Text;
            userTrack = this.track.Text;
           
        }

        private void skip_Click(object sender, EventArgs e)
        {

        }
    }
}
