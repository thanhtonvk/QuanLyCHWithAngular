using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QuanLyCHWithAngular.EF;

namespace QuanLyCHWithAngular.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        DBContext db = new DBContext();
        // GET: Admin/Product
       

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllData(string searchString)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Product> categorieList = db.Products.Where(x => x.IsDeleted == false).ToList();
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
        public string InsertData(Product product)
        {
            if (product != null)
            {
                product.IsDeleted = false;
                db.Products.Add(product);
                db.SaveChanges();
                return "Thêm thành công";
            }
            else
            {
                return "Thêm không thành công";
            }
        }
        public string UpdateData(Product product)
        {
            if (product != null)
            {
                
                var _product = db.Entry(product);
                Product cateObj = db.Products.Where(x => x.ID == product.ID).FirstOrDefault();
                cateObj.Name = product.Name;
                cateObj.Details = product.Details;
                cateObj.Cost = product.Cost;
                cateObj.Image = product.Image;
                cateObj.IDCategory = product.IDCategory;
                cateObj.IsDeleted = false;
                db.SaveChanges();
                return "Update thành công";
            }
            else
            {
                return "Update không thành công";
            }
        }
        public string DeleteData(Product product)
        {
            if (product != null)
            {
                Product cateObj = db.Products.Where(x => x.Name == product.Name).FirstOrDefault();
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