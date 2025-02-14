using System;

namespace ProjeYonetim1.Models
{
    public class Task
    {
        public int Id { get; set; }
        public int ProjeId { get; set; }
        public string GorevAdi { get; set; }
        public string Aciklama { get; set; }
        public string AtananKullanici { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Durum { get; set; }
    }
}
