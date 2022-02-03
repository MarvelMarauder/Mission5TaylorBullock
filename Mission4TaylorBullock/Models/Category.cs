using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4TaylorBullock.Models
{
    public class Category
    {
        [Required]
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
