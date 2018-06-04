using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace S2ITSolution_MVC.ViewModels
{
    public class AmigoViewModel
    {
        [Key]
        public int ID_Amigo { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Você deve informar o nome.")]
        [MinLength(3, ErrorMessage = "O nome deve ter mínimo 3 caracteres.")]
        public string NM_Amigo { get; set; }   
    }
}
