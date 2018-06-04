using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2ITSolution_MVC.ViewModels
{
    public class EmprestimoViewModel
    {
        [Key]
        public int ID_Emprestimo { get; set; }

        [DisplayName("Nome")]
        public int ID_Amigo { get; set; }

        public string NM_Amigo { get; set; }

        [DisplayName("Jogo")]
        public int ID_Jogo { get; set; }
        public string NM_Jogo { get; set; }

        [DisplayName("Data do Emprestimo")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DH_Emprestimo { get; set; }

        [DisplayName("Data da Devolucao")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd} H:mm:ss", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> DH_Devolucao { get; set; }

    }
}