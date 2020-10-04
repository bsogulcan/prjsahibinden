using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DataCollector.Helpers
{
    class ParseHtml
    {
        public static string GetAdTitle(HtmlElement html)
        {
            return html.InnerText.Split(Environment.NewLine)[0];
        }
        public static string GetAdNo(HtmlElement html)
        {
            return html.InnerText.Split(Environment.NewLine)[1].Substring(9, 10);
        }
        public static string GetAdPrice(HtmlElement html)
        {
            return html.InnerText.Split(Environment.NewLine)[1].Substring(19).Split(" ")[0];
        }
        public static string GetNumberOfViews(WebBrowser webBrowser)
        {
            try
            {
                string result = string.Empty;
                var spans = webBrowser.Document.GetElementById("counterBody").InnerHtml.Split("span><span");

                foreach (string span in spans)
                {
                    result += span.Substring(span.IndexOf("num") + 3, 1);
                }
                return result;

            }
            catch 
            {
                return "0";

            }



        }
    }
}
