using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models.OrderViewModels
{
    public class FormViewModel
    {
        public IDictionary<Kitchen, List<Dish>> KitchenDishes { get; set; }
        public IList<DinnerTable> Tables { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [Display(Name = "Leveren aan tafel")]
        public Guid TableId { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        public int ClientId { get; internal set; }
        
        public Dictionary<int, int> DishOrders { get; set; }

        public bool IsUpdate { get; set; }

        [Display(Name ="Dit tafelnummer instellen als nieuw standaard tafelnummer voor de klant")]
        public bool IsNewDefaultTable { get; set; }
    }
}
