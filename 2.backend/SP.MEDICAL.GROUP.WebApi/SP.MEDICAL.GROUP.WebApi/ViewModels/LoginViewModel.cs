using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP.MEDICAL.GROUP.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira a senha")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "A senha deve ter entre 3 e 150")]
        public string Senha { get; set; }
    }
}
