﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4TaylorBullock.Models
{
    public class MovieResponse
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }

        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
