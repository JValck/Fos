using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime InsertedAt { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public Guid DinnerTableId { get; set; }
        public DinnerTable DinnerTable { get; set; }

        public ICollection<DishOrder> DishOrders { get; set; }
    }
}
