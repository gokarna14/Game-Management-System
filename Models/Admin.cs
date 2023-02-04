using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameManagementSystem.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string? MiddleName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("User Name")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
        [Required]
        public DateTime Updated { get; set; } = DateTime.Now;
    }
}