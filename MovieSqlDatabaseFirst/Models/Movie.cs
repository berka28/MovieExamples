using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MovieSqlDatabaseFirst.Models
{
    public partial class Movie
    {
        [Key]
        [Column("EAN")]
        public int Ean { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Genre { get; set; }
        public bool Watched { get; set; }
        public DateTime Bought { get; set; }

        public Movie(string name, string genre)
        {
            Name = name;
            Genre = genre;
            Watched = false;
            Bought = DateTime.Now;
        }
    }
}
