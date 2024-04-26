namespace FitnessPlace.Business.DTOs
{
    public class MemberDetailDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public int MemberId { get; set; }
        public MemberDto Member { get; set; }
    }
}