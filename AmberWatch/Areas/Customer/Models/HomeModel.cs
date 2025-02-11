using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmberWatch.Areas.Customer.Models
{
    public class HomeModel
    {
        public IEnumerable<WatchModel> watchModels {get; set; }
        public IEnumerable<WatchModel> watchModelAuto {get; set; }
        public IEnumerable<WatchModel> watchModelQuartz {get; set; }
    }
}