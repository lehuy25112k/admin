using ModelEF;
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
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var category = new CategoryDao();
            var model = category.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var category = new CategoryDao();
            var model = category.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult Create(string user)
        {
            var dao = new CategoryDao();
            var result = dao.GetById(user);
            if (result != null)
                return View(result);
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {

            if (ModelState.IsValid)
            {
                var user = new CategoryDao();
                if (string.IsNullOrEmpty(model.Description))
                {
                    SetAlert("Không để trống mô tả", "warning");
                    return View();
                }
                string result = user.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Tạo mới thể loại thành công", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    SetAlert("Tạo mới thể loại không thành công", "error");
                    //ModelState.AddModelError("", "Thêm mới thể loại không thành công");
                }
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CategoryDao().Delete(id);

            return RedirectToAction("Index");
        }
    }

}