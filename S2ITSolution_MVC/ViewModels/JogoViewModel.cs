using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace S2ITSolution_MVC.ViewModels
{
    public class JogoViewModel
    {
        [Key]
        public int ID_Jogo { get; set; }

        [DisplayName("Nome do Jogo")]
        [Required(ErrorMessage = "Você deve informar o nome.")]
        [MinLength(3, ErrorMessage = "O nome deve ter mínimo 3 caracteres.")]
        public string NM_Jogo { get; set; }
    }
}