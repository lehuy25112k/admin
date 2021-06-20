using ModelEF.DAO;
using ModelEF.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {
        // GET: Admin/Products
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var product = new ProductDao();
            var model = product.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var product = new ProductDao();
            var model = product.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpGet]
        public ActionResult Create(string user)
        {
            var dao = new ProductDao();
            var result = dao.GetById(user);
            SetViewBag();
            if (result != null)
                return View(result);
            
            return View();
        }
  
        public void SetViewBag(long? selectedid = null)
        {
            var category = new CategoryDao();
            ViewBag.Category_ID = new SelectList(category.ListAll(), "ID", "Name", selectedid);
        }

        //[HttpPost]
        //public ActionResult Create(Product model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        var prd = new ProductDao();
        //        if (string.IsNullOrEmpty(model.Status))
        //        {
        //            SetAlert("Không để trống trạng thái", "warning");
        //            return View();
        //        }
        //        string result = prd.Insert(model);
        //        if (!string.IsNullOrEmpty(result))
        //        {
        //            SetAlert("Tạo mới thể loại thành công", "success");
        //            return RedirectToAction("Index", "Products");
        //        }
        //        else
        //        {
        //            SetAlert("Tạo mới thể loại không thành công", "error");
        //            //ModelState.AddModelError("", "Thêm mới thể loại không thành công");
        //        }
        //    }
        //    return View();
        //}

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);

            return RedirectToAction("Index");
        }

      
    }
}