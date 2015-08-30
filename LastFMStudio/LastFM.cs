using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Net.Http.Formatting;
using System.Web;


namespace LastFMLib
{
    namespace GetArtists
    {
        public class Image
        {
            [Newtonsoft.Json.JsonProperty("#text")]
            public string text { get; set; }
            public string size { get; set; }
        }

        public class Artist
        {
            public string name { get; set; }
            public string playcount { get; set; }
            public string tagcount { get; set; }
            public string mbid { get; set; }
            public string url { get; set; }
            public string streamable { get; set; }
            public List<Image> image { get; set; }
        }

        public class Attr
        {
            public string user { get; set; }
            public string page { get; set; }
            public string perPage { get; set; }
            public int totalPages { get; set; }
            public string total { get; set; }
        }

        public class Artists
        {
            public List<Artist> artist { get; set; }
            [Newtonsoft.Json.JsonProperty("@attr")]
            public Attr attr { get; set; }
        }

        public class RootObject
        {
            public Artists artists { get; set; }
        }
    }

    namespace GetRecentTracks
    {

        public class Attr
        {
            public string user { get; set; }
            public string page { get; set; }
            public string perPage { get; set; }
            public int totalPages { get; set; }
            public string total { get; set; }
        }

        public class Artist
        {
            [Newtonsoft.Json.JsonProperty("#text")]
            public string text { get; set; }
            public string mbid { get; set; }
        }

        public class Album
        {
            [Newtonsoft.Json.JsonProperty("#text")]
            public string text { get; set; }
            public string mbid { get; set; }
        }

        public class Image
        {
            [Newtonsoft.Json.JsonProperty("#text")]
            public string text { get; set; }
            public string size { get; set; }
        }

        public class Date
        {
            public string uts { get; set; }
            [Newtonsoft.Json.JsonProperty("#text")]
            public string text { get; set; }
        }

        public class Track
        {
            public Artist artist { get; set; }
            public string name { get; set; }
            public string streamable { get; set; }
            public string mbid { get; set; }
            public Album album { get; set; }
            public string url { get; set; }
            public List<Image> image { get; set; }
            public Date date { get; set; }
            [Newtonsoft.Json.JsonIgnore]
            public int playCount { get; set; }

        }

        public class Recenttracks
        {
            public List<Track> track { get; set; }
            [Newtonsoft.Json.JsonProperty("@attr")]
            public Attr attr { get; set; }
        }

        public class RootObject
        {
            public Recenttracks recenttracks { get; set; }
        }

    }

    namespace GetAlbums
    {
        public class Attr
        {
            public string user { get; set; }
            public string page { get; set; }
            public string perPage { get; set; }
            public int totalPages { get; set; }
            public string total { get; set; }
        }

        public class Album
        {
            public string name { get; set; }
        }

        public class Albums
        {
            public List<Album> album { get; set; }
            [Newtonsoft.Json.JsonProperty("@attr")]
            public Attr attr { get; set; }
        }

        public class RootObject
        {
            public Albums albums { get; set; }
        }

    }

    namespace GetTracks
    {
        public class Attr
        {
            public string user { get; set; }
            public string page { get; set; }
            public string perPage { get; set; }
            public int totalPages { get; set; }
            public string total { get; set; }
        }

        public class Track
        {
        }

        public class Tracks
        {
            public List<Track> track { get; set; }
            [Newtonsoft.Json.JsonProperty("@attr")]
            public Attr attr { get; set; }
        }

        public class RootObject
        {
            public Tracks tracks { get; set; }
        }

    }

    class LastFM
    {
        private readonly string apiKey;
        private readonly string apiUrl;

        public LastFM()
        {
            this.apiKey = "";
            this.apiUrl = "http://ws.audioscrobbler.com/2.0/";
        }

        private T Deserialize<T>(MediaTypeFormatter formatter, string str) where T : class
        {
            // Write the serialized string to a memory stream.
            Stream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            // Deserialize to an object of type T
            return formatter.ReadFromStreamAsync(typeof(T), stream, null, null).Result as T;
        }


        public List<GetArtists.Artist> getArtists(string user)
        {
            // e.g. http://ws.audioscrobbler.com/2.0/?method=library.getartists&api_key=533d6a1c6e256f5c1971ee1bb6624222&user=joanofarctan
            string request = "?method=library.getArtists&user=" + user + this.apiKey + "&format=json";
            GetArtists.RootObject first = getList<GetArtists.RootObject>(request);
            List<GetArtists.Artist> list = new List<GetArtists.Artist>();
            list.AddRange(first.artists.artist);
            for (int i = 1; i < first.artists.attr.totalPages; ++i)
            {
                GetArtists.RootObject next = getList<GetArtists.RootObject>(request + "&page=" + (i+1).ToString());
                list.AddRange(next.artists.artist);
            }
            return list;
        }

        public List<GetAlbums.Album> getAlbums(string user, string artistName)
        {
            artistName = System.Web.HttpUtility.UrlEncode(artistName, System.Text.Encoding.UTF8);
            string request = "?method=library.getAlbums&user=" + user + "&artist=" + artistName + this.apiKey + "&format=json";
            GetAlbums.RootObject first = getList<GetAlbums.RootObject>(request);
            List<GetAlbums.Album> list = new List<GetAlbums.Album>();
            list.AddRange(first.albums.album);
            for (int i = 1; i < first.albums.attr.totalPages; ++i)
            {
                GetAlbums.RootObject next = getList<GetAlbums.RootObject>(request + "&page=" + (i + 1).ToString());
                list.AddRange(next.albums.album);
            }
            return list;
        }

        public List<GetTracks.Track> getTracks(string user, string artistName, string albumName)
        {
            artistName = System.Web.HttpUtility.UrlEncode(artistName, System.Text.Encoding.UTF8);
            albumName = System.Web.HttpUtility.UrlEncode(albumName, System.Text.Encoding.UTF8);
            string request = "?method=library.getTracks&user=" + user + "&artist=" + artistName + "&album=" + albumName + this.apiKey + "&format=json";
            GetTracks.RootObject first = getList<GetTracks.RootObject>(request);
            List<GetTracks.Track> list = new List<GetTracks.Track>();
            list.AddRange(first.tracks.track);
            for (int i = 1; i < first.tracks.attr.totalPages; ++i)
            {
                GetTracks.RootObject next = getList<GetTracks.RootObject>(request + "&page=" + (i + 1).ToString());
                list.AddRange(next.tracks.track);
            }
            return list;
        }

        private T getList<T>(string request) where T : class
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this.apiUrl);
            //client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(request).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                //getArtists = response.Content.ReadAsAsync<GetArtistsResponse>().Result;
                var str = response.Content.ReadAsStringAsync().Result;
                var json = new JsonMediaTypeFormatter();
                json.SerializerSettings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
                try
                {
                    return Deserialize<T>(json, str);
                }
                catch (System.AggregateException ae)
                {
                    ae.Handle((x) => { throw x; });
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return default (T);
        }

        public List<GetRecentTracks.Track> getRecentTracks(string user, string from)
        {
            string request = "?method=user.getRecentTracks&user=" + user + "&from=" + from + this.apiKey + "&format=json";
            GetRecentTracks.RootObject recent = getList<GetRecentTracks.RootObject>(request);
            List<GetRecentTracks.Track> list = new List<GetRecentTracks.Track>();
            list.AddRange(recent.recenttracks.track);
            for (int i = 1; i < recent.recenttracks.attr.totalPages; ++i)
            {
                GetRecentTracks.RootObject next = getList<GetRecentTracks.RootObject>(request + "&page=" + (i + 1).ToString());
                list.AddRange(next.recenttracks.track);
            }
            return list;
        }

    }
}

