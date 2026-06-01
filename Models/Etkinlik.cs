using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cagan_cakmakcilar_sinav.Models
{
    [Table("Sinav_Etkinlikler")]
    public class Etkinlik
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Etkinlik adı zorunludur!")]
        public string Ad { get; set; } = "";

        [Required(ErrorMessage = "Tarih seçmelisiniz!")]
        public DateTime Tarih { get; set; } = DateTime.Now;

        public int Kontenjan { get; set; }
    }
}