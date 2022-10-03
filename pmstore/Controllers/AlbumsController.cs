using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pmstore.Data;
using pmstore.Data.Service;
using pmstore.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace pmstore.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService _service;

        public AlbumsController(IAlbumsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allAlbums = await _service.GetAllAsync(n => n.Streaming);
            return View(allAlbums);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allAlbums = await _service.GetAllAsync(n => n.Streaming);

            if (!string.IsNullOrEmpty(searchString))
            {

                var filteredResultNew = allAlbums.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }
            return View(allAlbums);
        }

        // Albums/Detail/1
        public async Task<IActionResult> Detail(int id)
        {
            var albumDetail = await _service.GetAlbumByIdAsync(id);
            return View(albumDetail);
        }

        // Albums/Create
        public async Task<IActionResult> Create()
        {
            var albumDropdownsData = await _service.GetNewAlbumDropdownsValues();

            ViewBag.Streamings = new SelectList(albumDropdownsData.Streamings, "Id", "Name");
            ViewBag.Producers = new SelectList(albumDropdownsData.Producers, "Id", "FullName");
            ViewBag.Artists = new SelectList(albumDropdownsData.Artists, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewAlbumVM album)
        {
            if (!ModelState.IsValid)
            {
                var albumDropdownsData = await _service.GetNewAlbumDropdownsValues();

                ViewBag.Streamings = new SelectList(albumDropdownsData.Streamings, "Id", "Name");
                ViewBag.Producers = new SelectList(albumDropdownsData.Producers, "Id", "FullName");
                ViewBag.Artists = new SelectList(albumDropdownsData.Artists, "Id", "FullName");

                return View(album);
            }

            await _service.AddNewAlbumAsync(album);
            return RedirectToAction(nameof(Index));
        }

        // Albums/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var albumDetail = await _service.GetAlbumByIdAsync(id);
            if (albumDetail == null) return View("Not Found");

            var response = new NewAlbumVM()
            {
                Id = albumDetail.Id,
                Name = albumDetail.Name,
                Description = albumDetail.Description,
                Price = albumDetail.Price,
                ReleaseDate = albumDetail.ReleaseDate,
                ImageURL = albumDetail.ImageURL,
                Genre = albumDetail.Genre,
                StreamingId = albumDetail.StreamingId,
                ProducerId = albumDetail.ProducerId,
                ArtistIds = albumDetail.Artists_Albums.Select(n => n.ArtistId).ToList(),
            };

            var albumDropdownsData = await _service.GetNewAlbumDropdownsValues();
            ViewBag.Streamings = new SelectList(albumDropdownsData.Streamings, "Id", "Name");
            ViewBag.Producers = new SelectList(albumDropdownsData.Producers, "Id", "FullName");
            ViewBag.Artists = new SelectList(albumDropdownsData.Artists, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewAlbumVM album)
        {
            if (id != album.Id) return View("Not Found");

            if (!ModelState.IsValid)
            {
                var albumDropdownsData = await _service.GetNewAlbumDropdownsValues();

                ViewBag.Streamings = new SelectList(albumDropdownsData.Streamings, "Id", "Name");
                ViewBag.Producers = new SelectList(albumDropdownsData.Producers, "Id", "FullName");
                ViewBag.Artists = new SelectList(albumDropdownsData.Artists, "Id", "FullName");

                return View(album);
            }

            await _service.UpdateAlbumAsync(album);
            return RedirectToAction(nameof(Index));
        }


    }
}
