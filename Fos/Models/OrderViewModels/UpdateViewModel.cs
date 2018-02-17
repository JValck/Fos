using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models.OrderViewModels
{
    public class UpdateViewModel:CreateViewModel
    {
        public UpdateViewModel()
        {
            IsUpdate = true;
        }
    }
}
