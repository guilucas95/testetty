using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TTYService;

namespace TTYClient.Models
{
    public class Fornecedor
    {

  
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name ="Nome")]
        [StringLength(100)]
        [Required(ErrorMessage = "Digite o Nome")]
        public string Nome { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Estado")]
        public string Estado { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Cidade")]
        public string Cidade { get; set; }
        public String Status { get; set; }
        public decimal Demanda { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Vigencia { get; set; }

        [Display(Name = "Contato Responsável")]
        public string NomeContato { get; set; }

        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}