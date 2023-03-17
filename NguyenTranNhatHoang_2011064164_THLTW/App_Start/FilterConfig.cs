using System.Web;
using System.Web.Mvc;

namespace NguyenTranNhatHoang_2011064164_THLTW
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
