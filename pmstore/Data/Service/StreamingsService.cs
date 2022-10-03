using pmstore.Data.BaseRepository;
using pmstore.Models;

namespace pmstore.Data.Service
{
    public class StreamingsService:EntityBaseRepo<Streaming>, IStreamingsService
    {
        public StreamingsService(AppDbContext context) : base(context)
        { 
        }
    }
}
