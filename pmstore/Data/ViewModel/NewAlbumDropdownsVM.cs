using pmstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pmstore.Data.ViewModels
{
    public class NewAlbumDropdownsVM
    {
        public NewAlbumDropdownsVM()
        {
            Producers = new List<Producer>();
            Streamings = new List<Streaming>();
            Artists = new List<Artist>();
        }

        public List<Producer> Producers { get; set; }
        public List<Streaming> Streamings { get; set; }
        public List<Artist> Artists { get; set; }
    }
}
