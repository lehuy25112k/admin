using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ModelEF
{
    public class CommonConstants
    {
        public static void WriteLog(string sPage, string sFunction, string sMessage)
        {
            try
            {
                string LogPath = HttpContext.Current.Server.MapPath("~/LogInfo");
                if (!System.IO.Directory.Exists(LogPath))
                {
                    System.IO.Directory.CreateDirectory(LogPath);
                }
                CLogger TestLogger = new CLogger();
                TestLogger.Initialize(LogPath, "SHOP.log", 2);
                TestLogger.LogInformation(sPage, sFunction, sMessage);
                TestLogger.Terminate();
            }
            catch (Exception)
            {

            }
        }
    }
}
