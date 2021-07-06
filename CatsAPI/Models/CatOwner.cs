using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAPI.Models
{
    public class CatOwner
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a the cat owner's name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a gender.")]
        public string Gender { get; set; }

        public ICollection<Cat> Cats { get; set; }

        public ICollection<FavoriteMovie> FavoriteMovies { get; set; }
    }
}
