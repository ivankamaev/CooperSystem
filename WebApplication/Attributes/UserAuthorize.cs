using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication.Attributes
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            //if (httpContext.User.Identity.IsAuthenticated)
            //{
            //    logger.Info("Вход пользователя (" + ((FormsIdentity)httpContext.User.Identity).Ticket.Name + ", " +
            //    ((FormsIdentity)httpContext.User.Identity).Ticket.UserData + ", " + httpContext.Request.Cookies.Get("id").Value + ")");
            //    return true;
            //}
            //else
            //{
            //    logger.Warn("Пользователь не авторизован");
            //    var cook = httpContext.Request.Cookies.Get(".ASPXAUTH");
            //    if (cook != null)
            //    {
            //        FormsAuthenticationTicket tick = FormsAuthentication.Decrypt(cook.Value);
            //        logger.Trace("Cookie.Ticket.Name = " + tick.Name);
            //        logger.Trace("Cookie.Ticket.UserData = " + tick.UserData);
            //    }
            //    else
            //    {
            //        logger.Trace("Cookie.Ticket.Name = null");
            //        logger.Trace("Cookie.Ticket.UserData = null");
            //    }

            //    if (httpContext.Request.Cookies.Get("id") != null)
            //    {
            //        logger.Trace("Cookie.Id = " + httpContext.Request.Cookies.Get("id").Value);
            //    }
            //    else
            //    {
            //        logger.Trace("Cookie.Id = null");
            //    }
            //    return false;
            //}


            if (httpContext.Request.Cookies.Get("email") != null && httpContext.Request.Cookies.Get("status") != null && httpContext.Request.Cookies.Get("id") != null)
            {
                logger.Info("Вход пользователя (id= " + httpContext.Request.Cookies.Get("id").Value + ", email = " + httpContext.Request.Cookies.Get("email").Value +
                    ", status = " + httpContext.Request.Cookies.Get("status").Value + ")");
                return true;
            }
            else
            {
                logger.Warn("Пользователь не авторизован");
                return false;
            }


        }
    }
}