using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace LastFMStudio
{
    class WmpLib
    {
        private WindowsMediaPlayer player = new WindowsMediaPlayer();
        private IWMPMediaCollection collection = null;
        private Dictionary<string, string> translator = new Dictionary<string, string>();

        public WmpLib()
        {
            IWMPSettings2 settings = (IWMPSettings2)player.settings;
            bool b = settings.requestMediaAccessRights("full");
            if (!b)
                throw new ApplicationException("No rights to modify media library");
            collection = player.mediaCollection;
        }

        private void translate(ref string artist, ref string album)
        {
            string key = "artist=" + artist + "&album=" + album;
            string value;
            if (translator.TryGetValue(key, out value))
            {
                var parts = value.Split('&');
                var artistPart = parts[0].Split('=');
                artist = artistPart[1];
                var albumPart = parts[1].Split('=');
                album = albumPart[1];
            }
        }

        public void incrementTrackPlaycount(string track, string album, string artist, int playCount)
        {
            translate(ref artist, ref album);
            IWMPPlaylist list = collection.getByAttribute("WM/AlbumTitle", album);
            for (int i = 0; i < list.count; ++i)
            {
                IWMPMedia item = list.get_Item(i);
                if (
                    (track.ToLower() == item.getItemInfo("Title").ToLower())
                    &&
                    (artist.ToLower() == item.getItemInfo("WM/AlbumArtist").ToLower())
                    &&
                    (album.ToLower() == item.getItemInfo("WM/AlbumTitle").ToLower())
                    )
                {
                    string pc = item.getItemInfo("UserPlayCount");
                    int p = int.Parse(pc) + playCount;
                    //item.setItemInfo("UserPlayCount", p.ToString());
                    Console.WriteLine("Updating: {0} {1} {2}", track, album, p);

                    return;
                }
            }
            Console.WriteLine("Not found: {0} {1} {2}", track, album, artist);
            skipOrRename(artist, album, track, playCount);
        }

        public void transferPlayCounts(string track, string album, string artist, int playCount)
        {
            translate(ref artist, ref album);
            IWMPPlaylist list = collection.getByAttribute("WM/AlbumTitle", album);
            for (int i = 0; i < list.count; ++i)
            {
                if (
                    (track.ToLower() == list.getItemInfo("Title").ToLower())
                    &&
                    (artist.ToLower() == list.getItemInfo("WM/AlbumArtist").ToLower())
                    &&
                    (artist.ToLower() == list.getItemInfo("WM/AlbumTitle").ToLower())
                    )
                {
                    list.setItemInfo("UserPlayCount", playCount.ToString());
                    return;
                }
            }
            Console.WriteLine("Not found: {0} {1} {2}", track, album, artist);
            skipOrRename(artist, album, track, playCount);
        }

        private void skipOrRename(string artist, string album, string track, int playCount)
        {
            SearchSkip dlg = new SearchSkip(artist, album, track);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((artist != dlg.userArtist) || (album != dlg.userAlbum))
                {
                    string key = "artist=" + artist + "&album=" + album;
                    string value = "artist=" + dlg.userArtist + "&album=" + dlg.userAlbum;
                    translator.Add(key, value);
                }
                incrementTrackPlaycount(dlg.userTrack, dlg.userAlbum, dlg.userArtist, playCount);
            }
        }
    }

}
