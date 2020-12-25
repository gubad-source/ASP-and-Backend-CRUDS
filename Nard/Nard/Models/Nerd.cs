using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nard.Models
{
    public class Nerd
    {
        public int Id { get; set; }
        [DisplayName("Basliq")]
        [Required]
        [MaxLength(200,ErrorMessage ="Lazim olan limiti kecib")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Metn")]
        [Column(TypeName = "ntext")]
        [MaxLength(1000,ErrorMessage ="Lazim olan limiti kecib")]
        public string Text { get; set; }
        [Required]
        [DisplayName("Tarixi secin")]
        public DateTime PublishDate { get; set; }
        [MaxLength(100)]
        public string Photo { get; set; }
        [NotMapped]
        [DisplayName("Şəkil(png,jpg,gif)")]
        public IFormFile Upload { get; set; }
        [Required]
        [DisplayName("Kateqoriyani secin")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
