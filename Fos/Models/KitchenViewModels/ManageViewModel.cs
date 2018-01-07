using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models.KitchenViewModels
{
    public class ManageViewModel
    {
        [Display(Name = "Naam")]
        [Required(ErrorMessage = "{0} is verplicht.")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "{0} moet tussen de {2} en {1} karakters lang zijn.")]
        public string Name { get; set; }

        public IList<Kitchen> Kitchens { get; set; }
    }
}
