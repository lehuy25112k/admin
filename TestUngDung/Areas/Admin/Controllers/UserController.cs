using ModelEF;
using ModelEF.DAO;
using ModelEF.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
            
       
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var user = new User();
            var model = user.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new User();
            var model = user.ListWhereAll(searchString, page, pagesize);
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
            var dao = new User();
            var result = dao.GetById(user);
            if (result != null)
                return View(result);
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserAcount model)
        {
            
            if (ModelState.IsValid)
            {
                var user = new User();
                if (string.IsNullOrEmpty(model.Password))
                {
                    SetAlert("Không để mật khẩu trống", "warning");
                    return View();
                }
                var pass = Common.EncryptMD5(model.Password);
                model.Password = pass;
                string  result = user.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Tạo mới người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    SetAlert("Tạo mới người dùng không thành công", "error");
                    //ModelState.AddModelError("", "Tạo người dùng không thành công");
                }
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new User().Delete(id);

            return RedirectToAction("Index");
        }

    }
}