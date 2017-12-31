using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "De {0} is verplicht")]
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Het {0} is verplicht")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        [Display(Name = "Aangemeld blijven?")]
        public bool RememberMe { get; set; }
    }
}
