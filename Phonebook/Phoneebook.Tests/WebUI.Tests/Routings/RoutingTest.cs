using System;
using System.Web;
using Moq;
using System.Web.Routing;
using WebUI;
using NUnit.Framework;

namespace Phoneebook.Tests.WebUI.Tests.Routings
{
    [TestFixture]
    public class RoutingTest
    {
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            var mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            var mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            return mockContext.Object;
        }

        private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object propertySet = null)
        {
            Func<object, object, bool> valCompare = (v1, v2) => { return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0; };

            var result = valCompare(routeResult.Values["controller"], controller) && valCompare(routeResult.Values["action"], action);

            if (propertySet != null)
            {
                var propInfo = propertySet.GetType().GetProperties();

                foreach (var pi in propInfo)
                {
                    if (!(routeResult.Values.ContainsKey(pi.Name) && valCompare(routeResult.Values[pi.Name], pi.GetValue(propertySet, null))))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        private void TestRouteMatch(string url, string controller, string action, object routeProperties = null, string httpMethod = "GET")
        {
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            var result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
        }

        private void TestRouteFail(string url)
        {
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            var result = routes.GetRouteData(CreateHttpContext(url));

            Assert.IsTrue(result == null || result.Route == null);
        }

        [Test]
        public void TestIncomingRoutes()
        {
            TestRouteMatch("~/Admin/Index", "Admin", "Index");
            TestRouteMatch("~/One/Two", "One", "Two");
            //TestRouteFail("~/Admin/Index/Segment");
            //TestRouteFail("~/Admin");

            TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Phonebook", "Phonebook", "Index");
            TestRouteMatch("~/Phonebook/Edit", "Phonebook", "Edit"); 
            //TestRouteFail("~/Phonebook/Edit/All");
        }
    }
}
