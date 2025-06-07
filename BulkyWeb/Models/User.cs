using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
	public class User
	{
        public int UserId { get; set; }

		[Required]
		public string UserName { get; set; }
		public string Email { get; set; }
    }
}
