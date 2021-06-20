using System.Web.Mvc;

namespace TestUngDung.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
               "Create_default",
               "Admin/{controller}/{action}/{user}",
               new { controller = "User", action = "Create", user = UrlParameter.Optional }
           );
            context.MapRoute(
              "Delete_default",
              "Admin/{controller}/{action}/{user}",
              new { controller = "User", action = "Delete", user = UrlParameter.Optional }
          );
            context.MapRoute(
               "User_Index_default",
               "Admin/{controller}",
               new { controller = "User", id = UrlParameter.Optional }
           );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { Controller="Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}