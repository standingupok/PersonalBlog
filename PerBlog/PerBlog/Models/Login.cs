﻿using System.ComponentModel.DataAnnotations;
namespace PerBlog.Models
{
    public class Login
    {
        [Key]
        [Required]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
