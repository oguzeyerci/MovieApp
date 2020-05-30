using System.ComponentModel.DataAnnotations;

namespace filmapp.webui.Models
{
    public class MovieModel
    {
        public int MovieId { get; set; }

        [Required(ErrorMessage="Zorunlu Alan!")]
        [StringLength(60,MinimumLength=2,ErrorMessage="Film adı 2 ile 60 harf arası olmalıdır!")]
        public string Name { get; set; }

        [Required(ErrorMessage="Zorunlu Alan!")]
        public string Category { get; set; }

        [Required(ErrorMessage="Zorunlu Alan!")]
        public string Review { get; set; }

        [Required(ErrorMessage="Zorunlu Alan!")]
        public string Stars { get; set; }

        [Required(ErrorMessage="Zorunlu Alan!")]
        public string Director { get; set; }

        [Required(ErrorMessage="Zorunlu Alan!")]
        [Range(1900,2030,ErrorMessage="1900 ile 2030 arasında bir yıl girmelisiniz!")]

        public int Year { get; set; }       
        public string ImageUrl { get; set; }    
    }
}