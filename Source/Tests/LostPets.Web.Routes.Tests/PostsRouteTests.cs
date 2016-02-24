namespace LostPets.Web.Routes.Tests
{
    using System.Web.Routing;

    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class PostsRouteTests
    {
        [Test]
        public void TestRouteById()
        {
            const string Url = "/Post/Mjc2NS4xMjMxMjMxMzEyMw==";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<PostsController>(c => c.Details("Mjc2NS4xMjMxMjMxMzEyMw=="));
        }
    }
}
