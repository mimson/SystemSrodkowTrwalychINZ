using System.Collections.Generic;

namespace SrodkiTrwale.Models.ViewModel
{
    public class GetRaportModelView2
    {
        public List<GetRaportModelView> users { get; set; }
        public int assetsRegisteredInLast30Days { get; set; }
    }
}