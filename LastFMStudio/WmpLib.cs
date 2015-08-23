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

        public WmpLib()
        {
            IWMPSettings2 settings = (IWMPSettings2)player.settings;
            bool b = settings.requestMediaAccessRights("full");
            if (!b)
                throw new ApplicationException("No rights to modify media library");
            collection = player.mediaCollection;
        }

        public void incrementTrackPlaycount(string track, string album, string artist)
        {
            IWMPPlaylist list = collection.getByAttribute("MediaType", "audio");
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
                    string playCount = item.getItemInfo("UserPlayCount");
                    int p = int.Parse(playCount) + 1;
                    item.setItemInfo("UserPlayCount", p.ToString());
                    Console.WriteLine("Updating: {0} {1} {2}", track, album, p);

                    return;
                }
            }
            Console.WriteLine("Not found: {0} {1} {2}", track, album, artist);
        }

        public void transferPlayCounts(string track, string album, string artist, string playCount)
        {
            IWMPPlaylist list = collection.getAll();
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
                    list.setItemInfo("UserPlayCount", playCount);
                    return;
                }
            }
            Console.WriteLine("Not found: {0} {1} {2}", track, album, artist);
        }
    }
}
