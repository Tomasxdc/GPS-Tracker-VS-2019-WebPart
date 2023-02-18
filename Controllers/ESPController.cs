using Microsoft.AspNetCore.Mvc;
using gpsapka.Database;
using gpsapka.Models;
using Microsoft.AspNetCore.Authorization;

namespace gpsapka.Controllers
{
    public class ESPController : ControllerBase
    {
        private readonly ILogger<ESPController> _logger;
        private readonly AppDBContext _dbContext;
        public ESPController(AppDBContext dBContext, ILogger<ESPController> logger)//konsrtuktor, získá služby z dependency injection
        {
            _logger = logger;
            _dbContext = dBContext;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostJSON([FromBody] PolohaIn polohaIn) //akce pro přijetí dat z esp
        {
            //kontrola struktury souboru
            if(ModelState.IsValid)
            {
                //přidání dat do databáze
                _dbContext.polohas.Add(new Poloha { lat = polohaIn.lat, lng = polohaIn.lng, cas = DateTime.Now.ToString() });
                _dbContext.SaveChanges();
                return Ok(); //vrácení úspěšného provedení požadavku
            }
            return BadRequest("badmodel"); //vrácení zprávy o chybném modelu
        }
    }
}
