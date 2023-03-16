using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class CodeSnippetModel
    {
        [Key]


        public Guid IdCodeSnippet { get; set; }
        [StringLength(100,ErrorMessage="Titlul poate contine maxim 100 caractere")]
public string Title { get; set; }
        public string ContentCode { get; set; }
        public Guid IdMember { get; set; }
        [Range(0,int.MaxValue,ErrorMessage="Revision trebuie sa fie pozitiv!")]
        public int Revision { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public bool IsPublished { get; set; }


    }
}
