using DataCollector.Controllers;
using DataCollector.Helpers;
using DataCollector.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataCollector
{
    public partial class frmMain : Form
    {
        WebBrowser webBrowser;
        Timer timer;
        string appName;
        string[] ads = { "865519334", "865515514", "865516470" };
        public frmMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            appName = Process.GetCurrentProcess().ProcessName + ".exe";
            if (SetIE8KeyforWebBrowserControl.Init(appName))
            {
                webBrowser = new WebBrowser();
                gbWebBrowser.Controls.Add(webBrowser);
                webBrowser.ScriptErrorsSuppressed = true;
                webBrowser.Dock = DockStyle.Fill;

                webBrowser.Navigate(@"https://secure.sahibinden.com/giris");
                webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
            }
            else
                this.Close();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            foreach (string adNo in ads)
            {
                webBrowser.Navigate(@$"https://www.sahibinden.com/ilan/{adNo}/detay/");

                while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                double price;
                var links = webBrowser.Document.GetElementsByTagName("div");
                foreach (HtmlElement link in links)
                {
                    try
                    {
                        if (link.GetAttribute("className") == "classified-sticky-header")
                        {
                            List<Advertisement> ads =clsMain.GetAds();
                            History history = new History();
                            var adTitle = ParseHtml.GetAdTitle(link);
                            history.AD_NO = adNo;
                            history.AD_PRICE = Convert.ToDouble(ParseHtml.GetAdPrice(link));
                            history.AD_VIEWS = Convert.ToInt32(ParseHtml.GetNumberOfViews(webBrowser));
                            history.CHECK_DATE = DateTime.Now;
                            clsMain.InsertHistory(history);
                            Advertisement ad = ads.Where(x => x.AD_TITLE == adTitle).FirstOrDefault();
                            if (ad!=null)
                                if (history.AD_PRICE<ad.MIN_PRCE)
                                    clsMain.SendMail(ad);
                            
                            
                            break;
                        }

                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            timer.Start();
        }


        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            memoLogs.Text = webBrowser.DocumentText;
            if (webBrowser.Url.LocalPath.Contains("giris"))
            {
                webBrowser.Document.GetElementById("username").InnerText = "prjsahibinden@gmail.com";
                webBrowser.Document.GetElementById("password").InnerText = "prjsahibinden46";

                foreach (HtmlElement HtmlElement1 in webBrowser.Document.Body.All)
                    if (HtmlElement1.GetAttribute("id") == "userLoginSubmitButton")
                    {
                        HtmlElement1.InvokeMember("click");
                        break;
                    }
            }
            else if (webBrowser.Url.AbsoluteUri == "https://banaozel.sahibinden.com/")
            {
                webBrowser.Navigate(@"https://www.sahibinden.com/ilan/865519334/detay/");
            }
            else if (webBrowser.Url.LocalPath.Contains("detay"))
            {
                webBrowser.DocumentCompleted -= WebBrowser_DocumentCompleted;
                timer.Start();

            }
        }

    }
}
