using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models.ClientViewModels
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "{0} is verplicht")]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [Display(Name = "Tafel")]
        public Guid TableId { get; set; }

        public List<DinnerTable> DinnerTables { get; set; }
    }
}
