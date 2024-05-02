using FitnessPlace.DataAccess.Models;
using FitnessPlace.DataAccess.Specifications;

namespace FitnessPlace.Business.Specifications
{
    public class MemberWithDetails : Specification<Member>
    {
        public MemberWithDetails() : base()
        {
            AddInclude(m => m.MemberDetail);
            AddOrderBy(m => m.FirstName);
        }

        public MemberWithDetails(int id) : base(m => m.Id == id)
        {
            AddInclude(m => m.MemberDetail);
            AddOrderBy(m => m.FirstName);
        }
    }
}