using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

    }
}
