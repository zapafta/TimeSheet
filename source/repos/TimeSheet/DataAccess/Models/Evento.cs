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
        public string Descricao { get; set; }

        [Required(ErrorMessage = "StartDate is required")]
        [Display(Order = 2)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is required")]
        [Display(Order = 3)]
        public DateTime EndDate { get; set; }

        [Display(Order = 5)]
        [Required(ErrorMessage = "Localizacao is required")]
        [ForeignKey("Localizacao")]
        public Guid IdLocalizacao { get; set; }
        public Localizacao Localizacao { get; set; }

        [Display(Order = 7)]
        [Required(ErrorMessage = "Obs is required")]
        public string Obs { get; set; }

        [Display(Order =9)]
        [Required(ErrorMessage = "Status is required")]
        public EnumStatus Status { get; set; }

        [Display(Order = 10)]
        [Required(ErrorMessage = "EventType is required")]
        public EnumEventType EventType { get; set; }

        [Display(Order = 11)]
        [Required(ErrorMessage = "Colaborador is required")]
        [ForeignKey("Colaborador")]
        public Guid IdColaborador { get; set; }
        public Colaborador Colaborador { get; set; }

        [NotMapped]
        public string Date { get; set; }

    }
}
