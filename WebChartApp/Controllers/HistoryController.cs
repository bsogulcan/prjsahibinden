using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebChartApp.Models;

namespace WebChartApp.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IConfiguration configuration;

        public HistoryController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index(Advertisement advertisementModel, HistoryModel historyModel)
        {
            if (historyModel.startDate.Year == 1)
            {
                historyModel.startDate = DateTime.Now.AddDays(-1);
                historyModel.endDate = DateTime.Now;
            }

            using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("DevConnection")))
            {
                conn.Open();
                historyModel.histories = conn.Query<History>($@"SELECT 
                                                        HISTORY.*,AD.AD_TITLE 
                                                    FROM 
                                                        AD_HISTORY HISTORY 
                                                        INNER JOIN ADVERTISEMENT AD ON AD.ID=HISTORY.AD_ID
                                                    WHERE
                                                        AD.ID='{advertisementModel.ID}'
                                                        AND HISTORY.CHECK_DATE BETWEEN @startDate AND @endDate", historyModel).ToList();
            }
            if (historyModel.histories.Count > 0)
                ViewData["Title"] = historyModel.histories.First().AD_TITLE;
            else
                ViewData["Title"] = "No Data";

            return View(historyModel);
        }

        [HttpGet]
        public IActionResult FilterHistory(HistoryModel historyModel)
        {


            using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("DevConnection")))
            {
                conn.Open();
                historyModel.histories = conn.Query<History>($@"SELECT 
                                                        HISTORY.*,AD.AD_TITLE 
                                                    FROM 
                                                        AD_HISTORY HISTORY 
                                                        INNER JOIN ADVERTISEMENT AD ON AD.ID=HISTORY.AD_ID
                                                    WHERE
                                                        AD.AD_NO='asd'      ").ToList();
            }

            ViewData["Title"] = historyModel.histories.First().AD_TITLE;


            historyModel.startDate = DateTime.Now.AddDays(-1);
            historyModel.endDate = DateTime.Now;

            return View(historyModel);
        }

    }

}
