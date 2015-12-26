using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;

namespace Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods:"*")]
    public class ValuesController : ApiController
    {
        private readonly Calculation _calc = new Calculation();

        // GET api/values
        public HttpResponseMessage Get(int num1, int num2, string act)
        {
            var result = _calc.Calculate(num1, num2, act);
            var response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
