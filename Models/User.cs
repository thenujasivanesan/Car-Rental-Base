using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 50 characters")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; } = "Customer"; // "Admin" or "Customer"

        // Navigation property
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
