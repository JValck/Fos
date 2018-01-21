using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models.OrderViewModels
{
    public class CreateViewModel
    {
        public IList<Dish> Dishes { get; set; }
        public IList<DinnerTable> Tables { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [Display(Name = "Leveren aan tafel")]
        public Guid TableId { get; set; }
    }
}
