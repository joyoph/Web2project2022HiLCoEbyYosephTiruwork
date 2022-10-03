using Microsoft.AspNetCore.Mvc;
using pmstore.Data;
using pmstore.Data.Service;
using pmstore.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace pmstore.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistsService _service;

        public ArtistsController(IArtistsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(); 
            return View(data);
        }

        // Artists/Create
        public IActionResult Create()
        { 
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePctureURL, Bio")] Artist artist)
        {
            if (ModelState.IsValid)
            { 
                return View(artist);
            }
            await _service.AddAsync(artist);
            return RedirectToAction(nameof(Index));
        }

        //  Artists/Detail/1
        public async Task<IActionResult> Detail(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);

            if (artistDetails == null) return View("Not Found");
            return View(artistDetails); 
        }

        // Artists/Update
        public async Task<IActionResult> Edit(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);
            if (artistDetails == null) return View("Not Found");
            return View(artistDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePctureURL, Bio")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                return View(artist);
            }
            await _service.updateAsync(id, artist);
            return RedirectToAction(nameof(Index));
        }

        //Get: Artists/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var artistDetail = await _service.GetByIdAsync(id);
            if (artistDetail == null) return View("Not Found");
            return View(artistDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artistDetail = await _service.GetByIdAsync(id);
            if (artistDetail == null) return View("Not Found");

            await _service.deleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
