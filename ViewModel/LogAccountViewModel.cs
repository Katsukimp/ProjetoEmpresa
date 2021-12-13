using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.ViewModel
{
    public class LogAccountViewModel
    {
        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição é requerida.")]
        public string Description { get; set; }

        [Display(Name = "Data de entrada")]
        [Required(ErrorMessage = "A data é requerida.")]
        public DateTime EntryDate { get; set; }

        [Display(Name = "Conta")]
        public string Account { get; set; }

        [Required(ErrorMessage = "A conta é obrigatória.")]
        public int IdAccount { get; set; }
    }
}
