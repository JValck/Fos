using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models
{
    public class DinnerTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public int TableNumber { get; set; }

        public ICollection<DinnerTableClient> DinnerTableClients { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
