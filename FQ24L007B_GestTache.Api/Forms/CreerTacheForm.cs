using System.ComponentModel.DataAnnotations;

namespace FQ24L007B_GestTache.Api.Forms
{
#nullable disable
    public class CreerTacheForm
    {
        [Required]
        [MinLength(1)]
        public string Titre { get; set; }
    }
}
