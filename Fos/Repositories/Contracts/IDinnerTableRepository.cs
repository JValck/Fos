using Fos.Data;
using Fos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories.Contracts
{
    public interface IDinnerTableRepository
    {
        IList<DinnerTable> GetAll();
    }
}
