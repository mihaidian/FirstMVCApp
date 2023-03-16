using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using FirstMVCApp.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembersRepository
    {
        private readonly ProgrammingClubDataContext _context;
        public MembersRepository (ProgrammingClubDataContext  context)
        {
            _context = context;
        }
        public DbSet<MemberModel> GetMembers()
        { return _context.Members; }
		public void Add(MemberModel model)
		{
			model.IdMember = Guid.NewGuid(); //setam id-ul
			_context.Members.Add(model); //adaugam modelul in layerul ORM(ProgrammingClubDataContext)
			_context.SaveChanges(); //commit to database
		}
		public MemberModel GetMemberById(Guid id)
		{
			MemberModel model = _context.Members.FirstOrDefault(x => x.IdMember == id);
			return model;
		}
		public void Update(MemberModel model)
		{
			_context.Members.Update(model);
			_context.SaveChanges();
		}
		public MemberCodeSnippetsViewModel GetMemberCodeSnippets(Guid memberID)
		{
			MemberCodeSnippetsViewModel memberCodesnippetsViewModel=new MemberCodeSnippetsViewModel();
			MemberModel member=_context.Members.FirstOrDefault(x=>x.IdMember==memberID);
			if(member!=null)
			{
				memberCodesnippetsViewModel.Name=member.Name;
				memberCodesnippetsViewModel.Position=member.Position;
				memberCodesnippetsViewModel.Title=member.Title;
				IQueryable<CodeSnippetModel> memberCodeSnippets=_context.CodeSnippets.Where(x=>x.IdMember==memberID);
				foreach(CodeSnippetModel dbCodeSnippet in memberCodeSnippets)
				{
					memberCodesnippetsViewModel.CodeSnippets.Add(dbCodeSnippet);
				}
			}
			return memberCodesnippetsViewModel;
		}
	}
}
