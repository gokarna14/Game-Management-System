using System.ComponentModel.DataAnnotations;

namespace GameManagementSystem.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
        [Required]
        public DateTime Updated { get; set; } = DateTime.Now;
    }
}