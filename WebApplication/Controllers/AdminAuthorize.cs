using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication.Controllers
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                if (((FormsIdentity)httpContext.User.Identity).Ticket.UserData == "Администратор")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
