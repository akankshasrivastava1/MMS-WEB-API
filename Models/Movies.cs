using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMS.Models
{
    public class Movies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string LeadActor { get; set; }
        public string Language { get; set; }
        public int Rating { get; set; }
        public int ReleaseYear { get; set; }

    }
}
