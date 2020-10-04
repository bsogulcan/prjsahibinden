using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebChartApp.Models
{
    public class HistoryModel
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<History> histories { get; set; }
    }

    public class History
    {
        public int ID { get; set; }
        public string AD_NO { get; set; }
        public string AD_TITLE { get; set; }
        public int AD_ID { get; set; }
        public double AD_PRICE { get; set; }
        public int AD_VIEWS { get; set; }
        public DateTime CHECK_DATE { get; set; }
    }
}
