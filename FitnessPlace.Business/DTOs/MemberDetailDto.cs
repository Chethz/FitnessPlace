using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPlace.Business.DTOs
{
    public class MemberDetailDto
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public MemberDto Member { get; set; }
    }
}