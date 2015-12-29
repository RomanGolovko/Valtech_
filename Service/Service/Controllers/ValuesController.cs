using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;
using Service.Models;

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

        public HttpResponseMessage Post([FromBody]Query query)
        {
            var result = _calc.Calculate(query.Num1, query.Num2, query.Action);
            var response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    } 
}
