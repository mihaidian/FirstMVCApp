using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembershipsRepository
    {
        private readonly ProgrammingClubDataContext _context;
        public MembershipsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }
        public DbSet<MembershipModel> GetMemberships() { return _context.Memberships; }
        public void AddMembership(MembershipModel model)
        {
            model.IdMembership=Guid.NewGuid();
            _context.Memberships.Add(model);
            _context.SaveChanges();

        }
    }
}
