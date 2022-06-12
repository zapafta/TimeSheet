using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class QuotesDay
    {
        [Key]
        [Display(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }


        [Display(Order = 1)]
        [Required(ErrorMessage = "Descrição is required")]
        public string Frase { get; set; }



    }
}
