using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeuBlog.Models
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual String Nome { get; set; }
        [Required]
        public virtual String Login { get; set; }
        [Required]
        public virtual String Password { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public virtual String Email { get; set; }                    
    }
}