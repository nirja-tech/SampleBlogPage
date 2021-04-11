using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace SampleBlogPage.Models
{
    public class BlogPage
    
        {
        [Key]
        [HiddenInput]
        [Required]
        public int ID { get; set; }


        [MaxLength(30)]
        [Required]
        public string Title { get; set; }

        [MaxLength(8000)]
        [Required]
        public string Content { get; set; }

        [MaxLength(30)]
        [Required]
        public string NewAuthor { get; set; }

        public DateTime PublishDate { get; set; }
    }
}

