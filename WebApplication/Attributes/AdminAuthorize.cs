using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication.Attributes
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            if (httpContext.Request.Cookies.Get("email") != null && httpContext.Request.Cookies.Get("status") != null && httpContext.Request.Cookies.Get("id") != null)
            {
                logger.Info("Вход пользователя (id= " + httpContext.Request.Cookies.Get("id").Value + ", email = " + httpContext.Request.Cookies.Get("email").Value +
                    ", status = " + httpContext.Request.Cookies.Get("status").Value + ")");
                if (httpContext.Request.Cookies.Get("status").Value == "admin")
                {
                    logger.Info("Доступ администратору " + httpContext.Request.Cookies.Get("email").Value + " разрешен");
                    return true;
                }
                else
                {
                    logger.Warn("Пользователь " + httpContext.Request.Cookies.Get("email").Value + " не является администратором");
                    return false;
                }
            }
            else
            {
                logger.Warn("Пользователь не авторизован");
                return false;
            }
        }
    }
}
