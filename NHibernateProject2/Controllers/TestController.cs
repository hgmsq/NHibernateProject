using NHibernateProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHibernateProject2.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            //var factory = NHibernateHelper.CreateSessionFactory();
            //return View("hello");
            return Content("执行一下");
        }
    }
}