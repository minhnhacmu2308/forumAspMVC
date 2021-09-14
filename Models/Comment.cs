using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace forumAspMVC.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(255)]
        [Required]
        public string text { get; set; }

        public virtual User User { get; set; }

        public virtual Post Post { get; set; }

        public DateTime createdAt { get; set; }

        public int status { get; set; }
    }
}