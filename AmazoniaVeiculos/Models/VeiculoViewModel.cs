using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AmazoniaVeiculos.Models
{
    public class VeiculoViewModel
    {
        public int Id { get; set; }
        [StringLength(30, ErrorMessage = "A marca precisa ter no mínimo 3 letras", MinimumLength = 3)]
        [Required(ErrorMessage = "O campo Marca é obrigatório")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "O campo Modelo é obrigatório")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "O campo KM é obrigatório")]
        public string KM { get; set; }
        [Required(ErrorMessage = "O campo Ano é obrigatório")]
        public string Ano { get; set; }


    }
}
