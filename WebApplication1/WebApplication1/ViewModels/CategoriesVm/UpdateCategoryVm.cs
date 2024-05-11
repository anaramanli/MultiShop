using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.Sliders
{
	public class UpdateCategoryVm
	{

		[MaxLength(32), Required]
		public string Name { get; set; }
		//[Required]
		//public string ImageUrl { get; set; }
	}
}
