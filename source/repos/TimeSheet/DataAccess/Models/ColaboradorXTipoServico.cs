using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
   public class ColaboradorXTipoServico
    {

        [Key]
        [Display(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }

        [ForeignKey("Colaborador")]
        public Guid IdColaborador { get; set; }
        public Colaborador Colaborador { get; set; }

        [ForeignKey("TipoServico")]
        public Guid IdTipoServico { get; set; }
        public TipoServico TipoServico { get; set; }


    }
}
