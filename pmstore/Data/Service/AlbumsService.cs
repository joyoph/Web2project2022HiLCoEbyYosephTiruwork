using Microsoft.EntityFrameworkCore;
using pmstore.Data.BaseRepository;
using pmstore.Data.ViewModels;
using pmstore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace pmstore.Data.Service
{
    public class AlbumsService : EntityBaseRepo<Album>, IAlbumsService
    {
        private readonly AppDbContext _context;
        public AlbumsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewAlbumAsync(NewAlbumVM data)
        {
            var newAlbum = new Album()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                StreamingId = data.StreamingId,
                ReleaseDate = data.ReleaseDate,
                Genre = data.Genre,
                ProducerId = data.ProducerId,
            };
            await _context.Albums.AddAsync(newAlbum);
            await _context.SaveChangesAsync();

            //Add Album Artist
            foreach (var artistId in data.ArtistIds)
            {
                var newArtistAlbum = new Artist_Album()
                {
                    AlbumId = newAlbum.Id,
                    ArtistId = artistId,
                };
                await _context.Artists_Albums.AddAsync(newArtistAlbum);
            }
            await _context.SaveChangesAsync();

        }

        public async Task<Album> GetAlbumByIdAsync(int id)
        {
            var albumDetail = _context.Albums
                .Include(s => s.Streaming)
                .Include(p => p.Producer)
                .Include(am => am.Artists_Albums).ThenInclude(a => a.Artist)
                .FirstOrDefaultAsync(n => n.Id == id);

            return await albumDetail;

        }

        public async Task<NewAlbumDropdownsVM> GetNewAlbumDropdownsValues()
        {
            var response = new NewAlbumDropdownsVM()
            {
                Artists = await _context.Artists.OrderBy(n => n.FullName).ToListAsync(),
                Streamings = await _context.Streamings.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync(),
            };

            return response;
        }

        // Update
        public async Task UpdateAlbumAsync(NewAlbumVM data)
        {
            var dbAlbum = await _context.Albums.FirstOrDefaultAsync(a => a.Id == data.Id);
            if (dbAlbum == null)

            {
                dbAlbum.Name = data.Name;
                dbAlbum.Description = data.Description;
                dbAlbum.Price = data.Price;
                dbAlbum.ImageURL = data.ImageURL;
                dbAlbum.StreamingId = data.StreamingId;
                dbAlbum.ReleaseDate = data.ReleaseDate;
                dbAlbum.Genre = data.Genre;
                dbAlbum.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();
            }

            //Remove Artists
            var existingArtistDb = _context.Artists_Albums.Where(n => n.AlbumId == data.Id).ToList();
            _context.Artists_Albums.RemoveRange(existingArtistDb);
            await _context.SaveChangesAsync();

            //Add Artists
            foreach (var artistId in data.ArtistIds)
            {
                var newArtistAlbum = new Artist_Album()
                {
                    AlbumId = data.Id,
                    ArtistId = artistId
                };
                await _context.Artists_Albums.AddAsync(newArtistAlbum);
            }
            await _context.SaveChangesAsync();
        }


    }
}

