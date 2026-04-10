using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using FlightSearchEngine.Data;
using FlightSearchEngine.Models;

namespace FlightSearchEngine.Controllers
{
    public class FlightController : Controller
    {
        private readonly DatabaseHelper _db;

        public FlightController(IConfiguration configuration)
        {
            _db = new DatabaseHelper(configuration);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new SearchViewModel();
            var sources = await _db.GetSourcesAsync();
            var destinations = await _db.GetDestinationsAsync();
            model.SourceList = new SelectList(sources);
            model.DestinationList = new SelectList(destinations);
            model.NumberOfPersons = 1;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchFlights(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Collect model state errors to help debugging on the page
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).Where(m => !string.IsNullOrWhiteSpace(m)).ToList();
                ViewBag.ModelErrors = errors;
                var sources = await _db.GetSourcesAsync();
                var destinations = await _db.GetDestinationsAsync();
                model.SourceList = new SelectList(sources);
                model.DestinationList = new SelectList(destinations);
                return View("Index", model);
            }

            // Redirect to GET paged results so pagination links work
            return RedirectToAction("PagedFlights", new { source = model.Source, destination = model.Destination, persons = model.NumberOfPersons, page = 1 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchFlightsWithHotels(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).Where(m => !string.IsNullOrWhiteSpace(m)).ToList();
                ViewBag.ModelErrors = errors;
                var sources = await _db.GetSourcesAsync();
                var destinations = await _db.GetDestinationsAsync();
                model.SourceList = new SelectList(sources);
                model.DestinationList = new SelectList(destinations);
                return View("Index", model);
            }

            // Redirect to GET paged results
            return RedirectToAction("PagedFlightHotels", new { source = model.Source, destination = model.Destination, persons = model.NumberOfPersons, page = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> PagedFlights(string source, string destination, int persons, int page = 1)
        {
            var all = await _db.SearchFlightsAsync(source, destination, persons);
            const int pageSize = 5;
            var total = all.Count;
            var totalPages = (int)System.Math.Ceiling(total / (double)pageSize);
            var items = all.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.Page = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.Source = source;
            ViewBag.Destination = destination;
            ViewBag.Persons = persons;
            return View("FlightsResults", items);
        }

        [HttpGet]
        public async Task<IActionResult> PagedFlightHotels(string source, string destination, int persons, int page = 1)
        {
            var all = await _db.SearchFlightsWithHotelsAsync(source, destination, persons);
            const int pageSize = 5;
            var total = all.Count;
            var totalPages = (int)System.Math.Ceiling(total / (double)pageSize);
            var items = all.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.Page = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.Source = source;
            ViewBag.Destination = destination;
            ViewBag.Persons = persons;
            return View("FlightHotelResults", items);
        }

        [HttpGet]
        public async Task<IActionResult> FlightDetails(int id)
        {
            var item = await _db.GetFlightByIdAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> FlightHotelDetails(int id)
        {
            var item = await _db.GetFlightHotelByFlightIdAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }
    }
}