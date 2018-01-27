using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models
{
    public class Dish
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int KitchenId { get; set; }
        public Kitchen Kitchen { get; set; }

        public bool Exhausted { get; set; }

        public ICollection<DishOrder> DishOrders { get; set; }
    }
}
