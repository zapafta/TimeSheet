using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
  public  class DadosBase
    {


        [Display(Order = 1)]
        [Required(ErrorMessage = "NomeCriacao is required")]
        public string NomeCriacao { get; set; }

        [Display(Order = 2)]
        [Required(ErrorMessage = "NomeEdicao is required")]
        public string NomeEdicao { get; set; }

        [Display(Order = 3)]
        [Required(ErrorMessage = "DataCriacao is required")]
        public DateTime DataCriacao { get; set; }

        [Display(Order = 4)]
        [Required(ErrorMessage = "DataEdicao is required")]
        public DateTime DataEdicao { get; set; }




    }
}
