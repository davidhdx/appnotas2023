using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Nutricion.API.Models
{
    public class Note
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "La {0} es requerida")]
        public string title { get; set; }
        public string text { get; set; }
        public DateTime lastModified { get; set; }
    }
}
