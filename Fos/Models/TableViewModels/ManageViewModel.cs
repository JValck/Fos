using Fos.Attributes;
using Fos.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models.TableViewModels
{
    public class ManageViewModel
    {
        public ICollection<DinnerTable> Tables { get; set; }

        [Display(Name = "Van")]
        [Range(0, int.MaxValue, ErrorMessage = "Gelieve een waarde op te geven die groter is dan 0")]
        public int CreateFrom { get; set; }
        [Display(Name = "Tot")]
        [Range(0, int.MaxValue, ErrorMessage = "Gelieve een waarde op te geven die groter is dan 0")]
        [GreaterThan("CreateFrom", ErrorMessage = "Moet groter zijn dan de beginwaarde [Van > Tot].")]
        public int CreateUntil { get; set; }
    }
}
