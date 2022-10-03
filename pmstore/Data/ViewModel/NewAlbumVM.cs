using pmstore.Data;
using pmstore.Data.BaseRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pmstore.Models
{
    public class NewAlbumVM
    {
        public int Id { get; set; }

        [Display(Name = "Album name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Album description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Album art URL")]
        [Required(ErrorMessage = "Album poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Album Release date")]
        [Required(ErrorMessage = "Release date is required")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Select a Genre")]
        [Required(ErrorMessage = "Album Genre is required")]
        public Genre Genre { get; set; }

        //Relationships
        [Display(Name = "Select artist(s)")]
        [Required(ErrorMessage = "Album artist(s) is required")]
        public List<int> ArtistIds { get; set; }

        [Display(Name = "Select a streaming service")]
        [Required(ErrorMessage = "Album stream is required")]
        public int StreamingId { get; set; }

        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "Album producer is required")]
        public int ProducerId { get; set; }
    }
}
