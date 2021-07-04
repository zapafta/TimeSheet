using DataAccess.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Evento
    {

        [Key]
        [Display(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }

        [Display(Order = 1)]
        [Required(ErrorMessage = "Descrição is required")]
        public string Descrição { get; set; }

        [Display(Order = 2)]
        [Required(ErrorMessage = "Cliente is required")]
        public Cliente Cliente { get; set; }

        [Display(Order = 3)]
        [Required(ErrorMessage = "Cliente is required")]
        public Localizacao Localizacao { get; set; }


        [Display(Order = 4)]
        [Required(ErrorMessage = "TipoServico is required")]
        public TipoServico TipoServico { get; set; }

        [Display(Order = 5)]
        [Required(ErrorMessage = "Descrição is required")]
        public string Obs { get; set; }

        [Display(Order = 6)]
        [Required(ErrorMessage = "Rating is required")]
        public int Rating { get; set; }


        [Display(Order =7)]
        [Required(ErrorMessage = "Status is required")]
        public EnumStatus Status { get; set; }







    }
}
