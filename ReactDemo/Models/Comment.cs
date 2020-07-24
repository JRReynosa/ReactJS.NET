using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReactDemo.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
