using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models
{
    public class KitchenOrder
    {
        public int KitchenId { get; set; }
        public Kitchen Kitchen { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
    }
}
