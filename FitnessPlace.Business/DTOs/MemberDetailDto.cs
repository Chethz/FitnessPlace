using System.ComponentModel.DataAnnotations;

namespace FitnessPlace.Business.DTOs
{
    public class MemberDetailDto
    {
        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public int MemberId { get; set; }
    }
}