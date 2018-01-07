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
        /// <summary>
        /// Creates an numer of tables depending on the <code>from</code> table number
        /// and the <code>until</code>.
        /// Table numbers that already exist in the interval are skipped.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="until"></param>
        void CreateInterval(int from, int until);
        bool Exists(int tableNumber);
        void Delete(Guid guid);
    }
}
