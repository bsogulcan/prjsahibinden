using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebChartApp.Models;

namespace WebChartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
         
        public IActionResult Index()
        {
            List<Advertisement> model = new List<Advertisement>();
            using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("DevConnection")))
            {
                conn.Open();
                model = conn.Query<Advertisement>("SELECT * FROM ADVERTISEMENT").ToList(); 
            }


            List<History> histories = null;

            using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("DevConnection")))
            {
                conn.Open();
                histories = conn.Query<History>($@"SELECT 
                                                        HISTORY.*,AD.AD_TITLE 
                                                    FROM 
                                                        AD_HISTORY HISTORY 
                                                        INNER JOIN ADVERTISEMENT AD ON AD.ID=HISTORY.AD_ID ").ToList();
            }

            ViewData["Datasource"] = histories;



            MainModel main = new MainModel();
            main.advertisements = model;
            main.histories = histories;
            return View(main);

             
        }

        [HttpPost]
        public IActionResult GetHistory(Advertisement advertisementModel)
        {
            return RedirectToAction("Index","History",advertisementModel);
        }




    }
}
