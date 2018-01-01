using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models.SetupViewModels
{
    public class SetupViewModel
    {
        public SetupViewModel()
        {
            UserName = Models.UserName.Admin;
        }

        [Required]
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Het {0} is verplicht")]
        [StringLength(100, ErrorMessage = "Het {0} moet minimaal {2} en maximum {1} karakters lang zijn.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord bevestigen")]
        [Compare("Password", ErrorMessage = "De wachtwoorden komen niet overeen.")]
        public string ConfirmPassword { get; set; }
    }
}
