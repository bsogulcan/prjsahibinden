using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChartApp.Models
{
    public partial class SampleData
    {
        public static readonly IEnumerable<History> OilProductionData = new[] {
            new History { AD_PRICE=10,AD_VIEWS=10,CHECK_DATE=DateTime.Now.Date },
            new History { AD_PRICE=18,AD_VIEWS=17,CHECK_DATE=DateTime.Now.Date},
            new History { AD_PRICE=17,AD_VIEWS=23,CHECK_DATE=DateTime.Now.Date}
        };
    }
}
