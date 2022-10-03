using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using pmstore.Data.BaseRepository;
using pmstore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pmstore.Data.Service
{
    public class ArtistsService : EntityBaseRepo<Artist>, IArtistsService
    {

        public ArtistsService(AppDbContext context) : base(context) { }

    }
}
