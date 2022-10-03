using Microsoft.AspNetCore.Mvc;
using pmstore.Data;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using pmstore.Data.Service;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using pmstore.Models;

namespace pmstore.Controllers
{
    public class StreamingsController : Controller
    {
        private readonly IStreamingsService _service;

        public StreamingsController(IStreamingsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allStreamings = await _service.GetAllAsync();
            return View(allStreamings);
        }

        // Streaming/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Streaming streaming)
        {
            if (!ModelState.IsValid) return View(streaming);
            await _service.AddAsync(streaming);
            return RedirectToAction(nameof(Index));
        }

        // Streaming/Detail/1
        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            var streamDetails = await _service.GetByIdAsync(id);
            if (streamDetails == null) return View("Not Found");
            return View(streamDetails);
        }

        // Streaming/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var streamDetails = await _service.GetByIdAsync(id);
            if (streamDetails == null) return View("Not Found");
            return View(streamDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Streaming streaming)
        {
            if (!ModelState.IsValid) return View(streaming);
            await _service.updateAsync(id, streaming);
            return RedirectToAction(nameof(Index));
        }

        // Streaming/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var streamDetails = await _service.GetByIdAsync(id);
            if (streamDetails == null) return View("Not Found");
            return View(streamDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var streamDetails = await _service.GetByIdAsync(id);
            if (streamDetails == null) return View("Not Found");

            await _service.deleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
