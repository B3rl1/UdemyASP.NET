using System.Web;
using System.Web.Mvc;

namespace ASPNetTest
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new AuthorizeAttribute());
			filters.Add(new RequireHttpsAttribute());//Сайт больше не будет доступен через HTTP протокол только HTTPS
		}
	}
}
