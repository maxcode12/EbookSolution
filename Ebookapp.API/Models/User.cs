using System.ComponentModel.DataAnnotations;

namespace Ebookapp.API.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress()]
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<Purchase> Purchases { get; set; }
    }
}
