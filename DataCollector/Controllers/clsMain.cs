using DataCollector.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DataCollector.Controllers
{
    class clsMain
    {
        public static bool InsertHistory(History historyModel)
        {
            try
            {
                var client = new RestClient("http://shbndn.puanimcepte.com/DATA");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(historyModel), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return true;
                else
                    return false;


            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static List<Advertisement> GetAds()
        {
            var client = new RestClient("http://shbndn.puanimcepte.com/DATA");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<Advertisement>>(response.Content);


        }
        public static void SendMail(Advertisement advertisement)
        {
            try
            {
                var fromAddress = new MailAddress("prjsahibinden@gmail.com", "Sahibinden DataCollector");
                var toAddress = new MailAddress(advertisement.EMAIL_ADRESS, advertisement.EMAIL_ADRESS);
                string fromPassword = "prjsahibinden46";
                string subject = "Takip Ettiğiniz İlanın Fiyatı Düştü";
                string body = advertisement.AD_TITLE + " Ürünü berlirlediğiniz fiyatın altına düşmüştür.";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,  
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                } 
            }
            catch
            {
                 
            }

        }

    }
}
