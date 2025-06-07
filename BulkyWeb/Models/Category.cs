using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
	public class Category
	{
		//[Key]
		public int CategoryId { get; set; }
		[Required]

		[DisplayName("Category Name")]
		[MaxLength(10)]
		public string CategoryName { get; set; }

		[DisplayName("Display Order")]
		[Range(1,100, ErrorMessage ="Shen Debilo")]
		public int DisplayOrder { get; set; }
	}
}
