using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models.ViewModels
{
    public class CarViewModel
    {
        public int CarID { get; set; }

        [Required(ErrorMessage = "Car name is required")]
        [StringLength(100, ErrorMessage = "Car name cannot exceed 100 characters")]
        public string CarName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Car brand is required")]
        [StringLength(50, ErrorMessage = "Car brand cannot exceed 50 characters")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Car model is required")]
        [StringLength(50, ErrorMessage = "Car model cannot exceed 50 characters")]
        public string CarModel { get; set; } = string.Empty;

        [Required(ErrorMessage = "Number of seats is required")]
        [Range(1, 50, ErrorMessage = "Number of seats must be between 1 and 50")]
        public int Seats { get; set; } = 4;

        [StringLength(200, ErrorMessage = "Image URL cannot exceed 200 characters")]
        public string? ImageUrl { get; set; }

        public IFormFile? ImageUpload { get; set; }

        public bool IsAvailable { get; set; } = true;

        public string? ExistingImagePath { get; set; }
    }
}
