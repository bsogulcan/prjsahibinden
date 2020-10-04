using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebChartApp.Models
{
    public class MainModel
    {
        public IEnumerable<Advertisement> advertisements { get; set; }
        public List<History> histories  { get; set; } 

    }
}
