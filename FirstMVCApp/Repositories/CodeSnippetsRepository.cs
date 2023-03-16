using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class CodeSnippetsRepository
    {
        private readonly ProgrammingClubDataContext _context;

        public CodeSnippetsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }


        public DbSet<CodeSnippetModel> GetCodeSnippets()
        { return _context.CodeSnippets; }
        public CodeSnippetModel GetCodeSnippetById(Guid id)
        {
            CodeSnippetModel codeSnippetModel = _context.CodeSnippets.FirstOrDefault(x=>x.IdCodeSnippet==id);
            return codeSnippetModel;
        }
        public void AddCodeSnippet(CodeSnippetModel codeSnippetModel)
        {
            codeSnippetModel.IdCodeSnippet= Guid.NewGuid();
            _context.Entry(codeSnippetModel).State=EntityState.Added;
            _context.SaveChanges();
        }
        public void UpdateCodeSnippet(CodeSnippetModel codeSnippetModel) 
        {
            _context.CodeSnippets.Update(codeSnippetModel); //_context.CodeSnippets.Add(codeSnippetModel);
            _context.SaveChanges();
        }
        public void DeleteCodeSnippet(Guid id) 
        {
CodeSnippetModel codeSnippetModel=GetCodeSnippetById(id);
            _context.CodeSnippets.Remove(codeSnippetModel);
            _context.SaveChanges();
        }
    }
}
