using System.Net;
using Bill.Core.Interfaces;

namespace Bill.Core
{
    public class BillService : IBillService
    {
        private const string ApiBaseUrl = "http://safe-plains-5453.herokuapp.com/bill.json";

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