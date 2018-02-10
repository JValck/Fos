using Fos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories.Contracts
{
    public interface IStatusRepository
    {
        /// <summary>
        /// Get the status when a dish order is included
        /// </summary>
        /// <returns></returns>
        Status GetIncludedStatus();

        /// <summary>
        /// Get the status when a dish order is updated
        /// </summary>
        /// <returns></returns>
        Status GetUpdatedStatus();

        /// <summary>
        /// Get the status when a dish order is completed
        /// </summary>
        /// <returns></returns>
        Status GetCompletedStatus();

        /// <summary>
        /// Get the status when a dish order is payed
        /// </summary>
        /// <returns></returns>
        Status GetPayedStatus();
    }
}
