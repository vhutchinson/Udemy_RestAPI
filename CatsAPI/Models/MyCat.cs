using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAPI.Models
{
    public class MyCat
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This cat needs a non-empty name! Not that it will ever answer to that name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter this cat's type.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please enter this cat's age.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter this cat's weight.")]
        public double Weight { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        public string ImageUrl { get; set; }
    }
}
