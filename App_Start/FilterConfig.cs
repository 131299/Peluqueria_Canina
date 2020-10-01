using System.Web;
using System.Web.Mvc;

namespace Peluqueria_canina_chichi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
