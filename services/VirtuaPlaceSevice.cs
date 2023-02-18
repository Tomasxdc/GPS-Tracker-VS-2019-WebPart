using gpsapka.Database;
using gpsapka.Models;

namespace gpsapka.services
{
    public class VirtuaPlaceSevice
    {
        private readonly AppDBContext _dbContext;
        public VirtuaPlaceSevice(AppDBContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public void CreateVitrual() //vytvoření virtualních žáznamů o poloze
        {
            _dbContext.polohas.Add(new Poloha { cas = DateTime.Now.ToString(), lat = 50.4622564, lng = 14.3741219 });
            _dbContext.polohas.Add(new Poloha { cas = DateTime.Now.ToString(), lat = 50.455298, lng = 14.379435 }); ;
            _dbContext.SaveChanges();
        }
    }
}
