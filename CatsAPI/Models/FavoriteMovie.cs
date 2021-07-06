using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAPI.Models
{
    public class FavoriteMovie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a movie title.")]
        public string Title { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        public string ImageUrl { get; set; }

        public int? CatOwnerId { get; set; }

        public int? MovieId { get; set; }
    }
}
