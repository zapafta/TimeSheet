using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
   public class HistoricoLocalizacao
    {
        [Key]
        [Display(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }

        [Display(Order = 1)]
        [Required(ErrorMessage = "Descrição is required")]
        public string Descrição { get; set; }

        [Display(Order = 3)]
        public double? Latitude { get; set; }
        [Display(Order = 4)]
        public double? Longitude { get; set; }


        [Display(Order = 5 )]
        public DateTime DataPedido { get; set; }








    }
}
