using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.ViewModel
{
    public class AccountViewModel
    {
        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Número da conta")]
        [Required(ErrorMessage = "O número da conta é requerido.")]
        public string AccountNumber { get; set; }

        [Display(Name = "Saldo inicial")]
        [Range(0, 99999999, ErrorMessage = "O valor inserido deve ser maior que 0.")]
        [Required(ErrorMessage = "O saldo é necessário.")]
        public decimal PreviousBalance { get; set; }

        [Display(Name = "Total débito")]
        [Range(0, 99999999, ErrorMessage = "O valor inserido deve ser maior que 0.")]
        public decimal TotalDebt { get; set; }

        [Display(Name = "Total crédito")]
        [Range(0, 99999999, ErrorMessage = "O valor inserido deve ser maior que 0.")]
        public decimal TotalCredit { get; set; }

        [Display(Name = "Saldo Total")]
        public decimal FinalBalance { get; set; }

        [Display(Name = "Nome do cliente")]
        public string Person { get; set; }

        [Required(ErrorMessage = "O cliente é obrigatória.")]
        public int IdPerson { get; set; }

        [Display(Name = "Nome do banco")]
        public string Bank { get; set; }

        [Required(ErrorMessage = "O banco é obrigatória.")]
        public int IdBank { get; set; }

        [Display(Name = "Ativo")]
        public bool Active { get; set; }

    }
}
