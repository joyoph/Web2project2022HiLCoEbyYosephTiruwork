using pmstore.Data.BaseRepository;
using pmstore.Data.ViewModels;
using pmstore.Models;
using System.Threading.Tasks;

namespace pmstore.Data.Service
{
    public interface IAlbumsService:IEntityBaseRepo<Album>
    {
        Task<Album> GetAlbumByIdAsync(int id);

        Task<NewAlbumDropdownsVM> GetNewAlbumDropdownsValues();

        Task AddNewAlbumAsync(NewAlbumVM data);

        Task UpdateAlbumAsync(NewAlbumVM data);
    }
}
