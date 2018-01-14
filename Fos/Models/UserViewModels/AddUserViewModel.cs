using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models.UserViewModels
{
    public class AddUserViewModel
    {
        [Required(ErrorMessage = "{0} is verplicht")]
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0} is verplicht")]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }
    }
}
