using FitnessPlace.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlace.DataAccess
{
    public class FitnessPlaceDbContext : DbContext
    {
        public FitnessPlaceDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<MemberDetail> MemberDetails { get; set; }
    }
}