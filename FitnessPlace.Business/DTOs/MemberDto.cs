using System.ComponentModel.DataAnnotations;

namespace FitnessPlace.Business.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public MemberDetailDto MemberDetail { get; set; }
    }
}