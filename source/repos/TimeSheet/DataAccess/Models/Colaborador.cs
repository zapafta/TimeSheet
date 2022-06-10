using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
   public class Colaborador
    {
        [Key]
        [Display(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }

        [Display(Order = 1)]
        [Required(ErrorMessage = "Name is required")]
        public string Nome { get; set; }

        [Display(Order = 2)]
        [Required(ErrorMessage = "BirthDate is required")]
        public DateTime BirthDate { get; set; }

     



    }
}
