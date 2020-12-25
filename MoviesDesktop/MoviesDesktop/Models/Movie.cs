using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MoviesDesktop.Models
{
   public class Movie
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Column(TypeName="date")]
        public DateTime ReleaseDate { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
