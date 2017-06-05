using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernateProject2.Models;
using NHibernate;
namespace NHibernateProject2.Controllers
{
 
    public class CategoryController : Controller
    {

        // http://blog.csdn.net/eqera/article/details/8442428
        // GET: Category
        public ActionResult Index()
        {
            var factory = NHibernateHelper.CreateSessionFactory();
            IEnumerable<Category> categories;
            using (var session = factory.OpenSession())
            {                
                categories = session.QueryOver<Category>().List();
            }
            return View(categories);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (category.Name == null || string.IsNullOrWhiteSpace(category.Name))
            {
                ModelState.AddModelError("", "类别不能为空");
                return View(category);
            }
            else
            {
                var factory = NHibernateHelper.CreateSessionFactory();
                using (var session = factory.OpenSession())
                {
                    session.Save(category);
                }
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            Category category = new Category();
            var factory = NHibernateHelper.CreateSessionFactory();
            using (var session = factory.OpenSession())
            {
                category = session.Get<Category>(id);
            }
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (category.Name == null || string.IsNullOrWhiteSpace(category.Name))
            {
                ModelState.AddModelError("", "类别不能为空");
                return View(category);
            }
            else
            {
                var factory = NHibernateHelper.CreateSessionFactory();
                using (var session = factory.OpenSession())
                {
                    ITransaction transactioin = session.BeginTransaction();
                    try {
                        session.Update(category);
                        transactioin.Commit();
                    }
                    catch
                    {
                        transactioin.Rollback();
                    }
                 
                }
                return RedirectToAction("Index");
            }
        }
         
        public ActionResult Delete(int id)
        {
            var factory = NHibernateHelper.CreateSessionFactory();
            using (var session = factory.OpenSession())
            {
                ITransaction tran = session.BeginTransaction();
                try {
                    var category = session.Get<Category>(id);
                    session.Delete(category);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }
            return RedirectToAction("Index");
        }
    }
}