using gpsapka.services;

namespace gpsapka.Models
{
    public class indexModel
    {
        public PaginatedList<Poloha> polohas { get; set; }
        public Poloha selected { get; set; }
    }
}
