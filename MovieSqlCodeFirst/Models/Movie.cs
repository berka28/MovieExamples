using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;

namespace MovieSqlCodeFirst.Models
{
    public class Movie
    {
        [Key]
        public int EAN { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Genre { get; set; }
        public bool Watched { get; set; }
        public DateTime Bought { get; set; }

        public Movie()
        {
            
        }

        public Movie(string name)
        {
            Name = name;
            Watched = false;
            Bought = DateTime.Now;
        }
    }
}
