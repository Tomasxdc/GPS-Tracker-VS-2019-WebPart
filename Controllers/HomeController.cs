using Microsoft.AspNetCore.Mvc;
using gpsapka.Database;
using gpsapka.Models;
using System.Linq;
using gpsapka.services;
using Microsoft.EntityFrameworkCore;

namespace gpsapka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBContext _dbContext;
        public HomeController(AppDBContext dBContext, ILogger<HomeController> logger)//konsrtuktor, získá služby z dependency injection
        {
            _logger = logger;
            _dbContext = dBContext;
        }

        public async Task<IActionResult> Index(int? recordId, int? pageNumber) //hl stránka
        {
            var polohas = from p in _dbContext.polohas select p; //získání poloh z databáze
            polohas = polohas.OrderByDescending(r => r.Id); //seřazení poloh podle id

            int pageSize = 10; //počet údajů na stránce

            if (recordId == null){ //žádný záznam nebyl vybrán
                //vrácení zobrazení Index
                return View(new indexModel { polohas = await PaginatedList<Poloha>.CreateAsync(polohas.AsNoTracking(), pageNumber ?? 1, pageSize), selected = new Poloha { Id = 0 } });
            }
            else//záznam byl vybrán
            {
                //vrácení zobrazení Index
                return View(new indexModel { polohas = await PaginatedList<Poloha>.CreateAsync(polohas.AsNoTracking(), pageNumber ?? 1, pageSize), selected = _dbContext.polohas.Where(p => p.Id == recordId).FirstOrDefault()});
            }
        }
    }
}
