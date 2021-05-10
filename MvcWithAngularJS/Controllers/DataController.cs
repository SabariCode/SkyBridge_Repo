using MvcWithAngularJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWithAngularJS.Controllers
{
    public class DataController : Controller
    {
        public DataController()
        {

        }

        public JsonResult UserLogin(LoginData login)
        {
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    var user = db.Users.Where(a => a.UserName.Equals(login.Username) && a.Password.Equals(login.Password)).FirstOrDefault();
                    return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch(System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach(var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach(var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("-Property: \"{0}\",Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        public JsonResult SaveProduct(ProductData product)
        {
            Product newproduct = new Product();
            newproduct.ProductID = product.ProductID;
            newproduct.ProductName = product.ProductName;
            newproduct.Availability = product.Availability;
            bool isSuccess = false;
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    var duplicate = db.Products.Where(a => a.ProductID.Equals(product.ProductID)).FirstOrDefault();

                    if(duplicate !=null && (duplicate?.ProductName == product.ProductName || duplicate?.Availability == product.Availability))
                    {
                        duplicate.ProductName = newproduct.ProductName;
                        duplicate.Availability = newproduct.Availability;
                        db.SaveChanges();
                        isSuccess = true;
                    }
                    else if (duplicate != null && (duplicate?.ProductName != product.ProductName || duplicate?.Availability != product.Availability))
                    {
                        duplicate.ProductName = newproduct.ProductName;
                        duplicate.Availability = newproduct.Availability;
                        db.SaveChanges();
                        isSuccess = true;
                    }
                    else if(duplicate == null)
                    {
                        db.Products.Add(newproduct);
                        db.SaveChanges();
                        isSuccess = true;
                    }
                    return new JsonResult { Data = isSuccess, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("-Property: \"{0}\",Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public JsonResult DeleteProduct(ProductData product)
        {
            bool deleteSuccess = false;
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    var deleteProduct = db.Products.Where(a => a.ProductID.Equals(product.ProductID)).FirstOrDefault();
                    db.Products.Remove(deleteProduct);
                    db.SaveChanges();
                    deleteSuccess = true;
                    return new JsonResult { Data = deleteSuccess, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("-Property: \"{0}\",Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public ActionResult Display()
        {
            return View();
        }
        public JsonResult getData()
        {
            List<Product> productList = new List<Product>();
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    
                    return new JsonResult { Data = db.Products.ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("-Property: \"{0}\",Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}