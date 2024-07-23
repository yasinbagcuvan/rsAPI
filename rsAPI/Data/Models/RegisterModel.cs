﻿using System.ComponentModel.DataAnnotations;

namespace rsAPI.Data.Models
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }    

        [Required]
        public string FullName { get; set; }
        [Required]
        public string ProfilePictureUrl { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}