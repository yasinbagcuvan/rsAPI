using rsAPI.Data.Entities.Abstract;

namespace rsAPI.Data.Entities.Concrete
{
    public class ilanlar : BaseEntity
    {
        public string ilanBaslik { get; set; }
        public string ilanAciklama { get; set; }
        public string ilanFiyat { get; set; }
        public string? ilanResmi { get; set; }
        public string ilanKategorisi { get; set; }
        public string ilanDaireTipi { get; set; }
        public string ilanKisi { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
