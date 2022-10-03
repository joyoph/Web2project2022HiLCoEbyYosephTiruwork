using pmstore.Data;
using pmstore.Data.BaseRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pmstore.Models
{
    public class Album:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }

        //Relationships
        public List<Artist_Album> Artists_Albums { get; set; }

        //Streaming
        public int StreamingId { get; set; }
        [ForeignKey("StreamingId")]
        public Streaming Streaming { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
