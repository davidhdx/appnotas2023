using SQLite;
using System;
using System.Collections.Generic;
//0using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutricion.Models
{
    [Table("Note")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int ID { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public DateTime lastModified { get; set; }
    }
}
