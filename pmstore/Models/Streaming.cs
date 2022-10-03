using pmstore.Data.BaseRepository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pmstore.Models
{
    public class Streaming : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Streaming Logo")]
        [Required(ErrorMessage = "Streaming logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Streaming Name")]
        [Required(ErrorMessage = "Streaming name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Streaming description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Album> Album { get; set; }
    }
}
