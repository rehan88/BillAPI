using System.Configuration;
using System.Net;
using Bill.Core.Interfaces;

namespace Bill.Core
{
    public class BillService : IBillService
    {
        private static readonly string ApiBaseUrl = ConfigurationManager.AppSettings["MySetting"];

        public string GetBill()
        {
            string billJson;
            using (var wc = new WebClient())
            {
                billJson = wc.DownloadString(ApiBaseUrl);
            }
            return billJson;
        }
    }
}