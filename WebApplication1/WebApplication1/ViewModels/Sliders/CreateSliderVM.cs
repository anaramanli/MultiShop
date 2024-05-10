using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.Sliders
{
    public class CreateSliderVM
    {
        [MaxLength(32, ErrorMessage = "Max Lengt is 32"), Required]
        public string Title { get; set; }
        [MaxLength(64)]
        public string Subtitle { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
