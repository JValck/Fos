using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models
{
    public class DinnerTableClient
    {
        public Guid DinnerTableId { get; set; }
        public DinnerTable DinnerTable { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
