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
            List<LastFMLib.GetArtists.Artist> artists = lastFM.getArtists(userBox.Text);
            if (null == artists)
                return;
            foreach (LastFMLib.GetArtists.Artist a in artists)
            {
                List<LastFMLib.GetAlbums.Album> albums = lastFM.getAlbums(userBox.Text, a.name);
                foreach (LastFMLib.GetAlbums.Album ab in albums)
                {
                    List<LastFMLib.GetTracks.Track> tracks = lastFM.getTracks(userBox.Text, a.name, ab.name);
                    foreach (LastFMLib.GetTracks.Track t in tracks)
                    {
                        //wmp.transferPlayCounts(t.name, t.album.text, t.artist.text, );
                    }
                }
            }
        }

        private void exportArtist_Click(object sender, EventArgs e)
        {
            List<LastFMLib.GetAlbums.Album> albums = lastFM.getAlbums(userBox.Text, artistBox.Text);
            foreach (LastFMLib.GetAlbums.Album ab in albums)
            {
                List<LastFMLib.GetTracks.Track> tracks = lastFM.getTracks(userBox.Text, artistBox.Text, ab.name);
                foreach (LastFMLib.GetTracks.Track t in tracks)
                {
                    //wmp.transferPlayCounts(t.name, t.album.text, t.artist.text, );
                }
            }

        }

        private void exportAlbum_Click(object sender, EventArgs e)
        {
            List<LastFMLib.GetTracks.Track> tracks = lastFM.getTracks(userBox.Text, artistBox.Text, albumBox.Text);
            foreach (LastFMLib.GetTracks.Track t in tracks)
            {
                //wmp.transferPlayCounts(t.name, t.album.text, t.artist.text, );
            }
        }

        static Predicate<LastFMLib.GetRecentTracks.Track> TrackName(LastFMLib.GetRecentTracks.Track track)
        {
            return delegate (LastFMLib.GetRecentTracks.Track t)
            {
                return (t.name == track.name) && (t.artist.text == track.artist.text) && (t.album.text == track.album.text);
            };
        }

        private void ExportScrobbles_Click(object sender, EventArgs e)
        {
            DateTime from = startDate.Value;
            DateTime unixTimeZero = new DateTime(1970, 1, 1, 0, 0, 0);
            string fromTime = (from - unixTimeZero).TotalSeconds.ToString();
            List<LastFMLib.GetRecentTracks.Track> recentTracks = lastFM.getRecentTracks(userBox.Text, fromTime);
            List<LastFMLib.GetRecentTracks.Track> uniqueTracks = new List<LastFMLib.GetRecentTracks.Track>();
            foreach (LastFMLib.GetRecentTracks.Track t in recentTracks)
            {
                LastFMLib.GetRecentTracks.Track ut = uniqueTracks.Find(TrackName(t));
                if(ut != null)
                {
                    ut.playCount += 1;
                }
                else
                {
                    t.playCount = 1;
                    uniqueTracks.Add(t);
                }
            }
            foreach (LastFMLib.GetRecentTracks.Track t in uniqueTracks)
            {
                wmp.incrementTrackPlaycount(t.name, t.album.text, t.artist.text, t.playCount);
            }
        }

    }
}
