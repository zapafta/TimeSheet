using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Person
    {

        [Key]
        [Display(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }

        [Display(Order = 1)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Order = 2)]
        [Required(ErrorMessage = "BirthDate is required")]
        public DateTime BirthDate { get; set; }


    }
}
