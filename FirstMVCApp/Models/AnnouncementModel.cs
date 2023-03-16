using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class AnnouncementModel
    {
        [Key]
        public Guid IdAnnouncement { get; set; }

        [Required(ErrorMessage="Acest camp este obligatoriu!!!")]
        public DateTime ValidFrom { get; set; }
        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public DateTime ValidTo { get; set; }
        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(250, ErrorMessage = "Campul Title poate contine 250 de caractere!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(250, ErrorMessage = "Campul Text poate contine 250 de caractere!")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]

        public DateTime EventDate { get; set; }
        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(250, ErrorMessage = "Campul Tags poate contine 250 de caractere!")]
        public string Tags { get; set; }
    }
}
