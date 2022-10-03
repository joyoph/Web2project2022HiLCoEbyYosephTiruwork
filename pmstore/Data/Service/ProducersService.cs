using pmstore.Data.BaseRepository;
using pmstore.Models;

namespace pmstore.Data.Service
{
    public class ProducersService : EntityBaseRepo<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        { 
        }
    }
}
