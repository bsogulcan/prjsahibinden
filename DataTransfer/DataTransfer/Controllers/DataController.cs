using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransfer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;

namespace DataTransfer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public DataController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        [HttpGet]
        public List<Advertisement> GetAds()
        {
            using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("DevConnection")))
            {
                conn.Open();
                return conn.Query<Advertisement>("SELECT * FROM ADVERTISEMENT").ToList();
            }
        }

        [HttpGet("{adNo}")]
        public List<History> GetHistoryOfAd(string adNo)
        {
            using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("DevConnection")))
            {
                conn.Open();
                return conn.Query<History>($@"SELECT 
                                                        * 
                                                    FROM 
                                                        AD_HISTORY HISTORY 
                                                        INNER JOIN ADVERTISEMENT AD ON AD.ID=HISTORY.AD_ID
                                                    WHERE
                                                        AD.AD_NO='{adNo}'").ToList();
            }
        }

        [HttpPost]
        public bool InsertHistory(History historyModel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("DevConnection")))
                {
                    conn.Open();
                    historyModel.AD_ID = conn.Query<int>($@"SELECT 
                                                        ID 
                                                    FROM 
                                                        ADVERTISEMENT
                                                    WHERE
                                                        AD_NO='{historyModel.AD_NO}'").FirstOrDefault();

                    conn.Execute("INSERT INTO AD_HISTORY(AD_ID,AD_PRICE,AD_VIEWS,CHECK_DATE) VALUES (@AD_ID,@AD_PRICE,@AD_VIEWS,@CHECK_DATE)", historyModel);

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }





        }

    }
}
