using QuanLyCHWithAngular.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCHWithAngular.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        DBContext db = new DBContext();
        // GET: Admin/Category
       

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllData(string searchString)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Category> categorieList = db.Categories.Where(x => x.IsDeleted == false).ToList();
            if (string.IsNullOrEmpty(searchString))
            {
                return Json(categorieList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var model = categorieList.Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }
        public string InsertData(Category category)
        {
            if (category != null)
            {
                category.IsDeleted = false;
                db.Categories.Add(category);
                db.SaveChanges();
                return "Thêm thành công";
            }
            else
            {
                return "Thêm không thành công";
            }
        }
        public string UpdateData(Category category)
        {
            if (category != null)
            {
                
                var _category = db.Entry(category);
                Category cateObj = db.Categories.Where(x => x.ID == category.ID).FirstOrDefault();
                cateObj.Name = category.Name;
                cateObj.IsDeleted = false;
                db.SaveChanges();
                return "Update thành công";
            }
            else
            {
                return "Update không thành công";
            }
        }
        public string DeleteData(Category category)
        {
            if (category != null)
            {
                Category cateObj = db.Categories.Where(x => x.Name == category.Name).FirstOrDefault();
                cateObj.IsDeleted = true;
                db.SaveChanges();
                return "Xóa thành công";
            }
            else
            {
                return "Xóa không thành công";
            }
        }

    }
}