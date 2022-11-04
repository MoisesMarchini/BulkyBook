using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "O campo 'Nome' deve ser preenchido")]
        [DisplayName("Nome")]
        public string Name { get; set; }


        [Required(ErrorMessage = "O campo 'Ordem de exibição' deve ser preenchido")]
        [DisplayName("Ordem de exibição")]
        [Range(1, 50, ErrorMessage = "Deve ser entre 1 e 50!")]
        public int DisplayOrder { get; set; }


        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}