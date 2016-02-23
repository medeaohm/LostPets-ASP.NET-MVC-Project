namespace LostPets.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using AutoMapper;

    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data;
    using Services.Web;

    public abstract class BaseController : Controller
    {
        private IUserService users;

        public BaseController(IUserService users)
        {
            this.users = users;
        }

        public IUserService Users
        {
            get
            {
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }

        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        protected User CurrentUser { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.CurrentUser = this.users
                .GetAll()
                .FirstOrDefault(u => u.UserName == requestContext.HttpContext.User.Identity.Name);

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}
