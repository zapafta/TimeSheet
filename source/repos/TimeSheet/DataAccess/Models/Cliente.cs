using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Cliente
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

        [Display(Order = 3)]
        [Required(ErrorMessage = "NIF is required")]
 
        public int NIF { get; set; }

        [Display(Order = 4)]
        [Required(ErrorMessage = "Email is required")]

        public string Email { get; set; }


        [Display(Order = 5)]
        [Required(ErrorMessage = "PhoneNumber is required")]

        public int PhoneNumber { get; set; }


    }
}
