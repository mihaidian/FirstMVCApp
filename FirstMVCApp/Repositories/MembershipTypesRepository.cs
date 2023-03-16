using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembershipTypesRepository
    {
        private readonly ProgrammingClubDataContext _context;
        public MembershipTypesRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }
        public DbSet<MembershipTypeModel> GetMembershipTypes()
        {
            return _context.MembershipTypes;
        }
		public void AddMembershipType(MembershipTypeModel model)
		{
			model.IdMembershipType = Guid.NewGuid(); //setam id-ul
			_context.MembershipTypes.Add(model); //adaugam modelul in layerul ORM(ProgrammingClubDataContext)
			_context.SaveChanges(); //commit to database
		}
		public MembershipTypeModel GetMembershipTypeById(Guid id)
		{
			MembershipTypeModel model = _context.MembershipTypes.FirstOrDefault(x => x.IdMembershipType == id);
			return model;
		}
		public void Update(MembershipTypeModel model) 
		{
			_context.MembershipTypes.Update(model);
			_context.SaveChanges();
		}
        public void Delete(Guid id)
        {
            MembershipTypeModel membership = GetMembershipTypeById(id);
            if (membership != null)
            {
                _context.MembershipTypes.Remove(membership);
                _context.SaveChanges();
            }

        }
    }
}
