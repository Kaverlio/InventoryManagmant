using DocumentFormat.OpenXml.Drawing;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net;

namespace InventoryManagmant
{
    
    class CheackDollar
    {
        public String cheackDollar() {
            WebClient client = new WebClient();
            var xml = client.DownloadString("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange");
            XDocument xdoc = XDocument.Parse(xml);
            var el = xdoc.Element("exchange").Elements("currency");
            string dollar_ua = el.Where(x => x.Element("r030").Value == "840").Select(x => x.Element("rate").Value).FirstOrDefault();
           
            return dollar_ua;
        }

        public double countAmount(int amt) {
            double result = Math.Round(amt / Convert.ToDouble(cheackDollar().Replace('.',',')), 2);
            return result;
        }
    }
}
