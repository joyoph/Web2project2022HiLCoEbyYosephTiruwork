using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pmstore.Models
{
    public class Artist_Album
    {
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
