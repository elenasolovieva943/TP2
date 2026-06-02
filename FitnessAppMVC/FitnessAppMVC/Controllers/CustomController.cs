using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FitnessAppMVC.Controllers
{
    public class CustomController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            string actionName = requestContext.RouteData.Values["action"]?.ToString();
            string id = requestContext.RouteData.Values["id"]?.ToString();

            var response = requestContext.HttpContext.Response;

            if (actionName == "start" && id == "0")
            {
                string url = VirtualPathUtility.ToAbsolute("~/Fitness/Index");
                response.Redirect(url, endResponse: false);
            }
            else
            {
                response.ContentType = "text/html; charset=utf-8";
                response.Write("<html><body>");
                response.Write("<h2 style='color:red;'>Ошибка!</h2>");
                response.Write("<p>Условия не выполнены. Ожидалось: action='start', id=0</p>");
                response.Write($"<p>Получено: action='{actionName}', id='{id}'</p>");
                response.Write($"<p>Полный URL: {requestContext.HttpContext.Request.Url}</p>");
                response.Write("</body></html>");
            }
        }
    }
}