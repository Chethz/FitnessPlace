using System.ComponentModel.DataAnnotations;

namespace FitnessPlace.DataAccess.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public MemberDetail MemberDetail { get; set; }
    }
}