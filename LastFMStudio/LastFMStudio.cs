using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LastFMLib;

namespace LastFMStudio
{
    public partial class LastFMStudio : Form
    {
        LastFM lastFM = new LastFM();
        WmpLib wmp = new WmpLib();

        public LastFMStudio()
        {
            InitializeComponent();
            startDate.Format = DateTimePickerFormat.Custom;
            startDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
        }

        private void ExportLibrary_Click(object sender, EventArgs e)
        {
            List<Artist> artists = lastFM.getArtists(userBox.Text);
            if (null == artists)
                return;
            foreach (Artist a in artists)
            {
                List<Album> albums = lastFM.getAlbums(userBox.Text, a.text);
                foreach (Album ab in albums)
                {
                    List<Track> tracks = lastFM.getTracks(userBox.Text, a.text, ab.text);
                    foreach (Track t in tracks)
                    {
                        //wmp.transferPlayCounts(t.name, t.album.text, t.artist.text, );
                    }
                }
            }
        }

        private void exportArtist_Click(object sender, EventArgs e)
        {
            List<Album> albums = lastFM.getAlbums(userBox.Text, artistBox.Text);
            foreach (Album ab in albums)
            {
                List<Track> tracks = lastFM.getTracks(userBox.Text, artistBox.Text, ab.text);
                foreach (Track t in tracks)
                {
                    //wmp.transferPlayCounts(t.name, t.album.text, t.artist.text, );
                }
            }

        }

        private void exportAlbum_Click(object sender, EventArgs e)
        {
            List<Track> tracks = lastFM.getTracks(userBox.Text, artistBox.Text, albumBox.Text);
        }

        private void ExportScrobbles_Click(object sender, EventArgs e)
        {
            DateTime from = startDate.Value;
            DateTime unixTimeZero = new DateTime(1970, 1, 1, 0, 0, 0);
            string fromTime = (from - unixTimeZero).TotalSeconds.ToString();
            List<Track> recentTracks = lastFM.getRecentTracks(userBox.Text, fromTime);

            foreach (Track t in recentTracks)
            {
                wmp.incrementTrackPlaycount(t.name, t.album.text, t.artist.text);
            }
        }

    }
}
