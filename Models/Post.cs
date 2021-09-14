using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace forumAspMVC.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(255)]
        [Required]
        public string title { get; set; }

        [StringLength(255)]
        [Required]
        public string image { get; set; }

        [StringLength(255)]
        [Required]
        public string description { get; set; }

        public int status { get; set; }
       
        public DateTime createdAt { get; set; }

        public virtual User User { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}