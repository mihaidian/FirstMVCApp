using FirstMVCApp.Models;
using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.ViewModel
{
	public class MemberCodeSnippetsViewModel
	{
		[Key]
		public string Name { get; set; }
		public string Title { get; set; }
		public string Position { get; set; }
		public List <CodeSnippetModel> CodeSnippets = new List <CodeSnippetModel> ();
	}
}
