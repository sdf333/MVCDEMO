using System.IO;
using System.Web;
using log4net;
using log4net.Config;

namespace Core
{

    public class LogHelper
    {
        static LogHelper()
        {
            var configPath = "Log4Net.config";
            if (HttpContext.Current != null)
            {
                configPath = HttpContext.Current.Server.MapPath("/Log4Net.config");
            }
            XmlConfigurator.ConfigureAndWatch(new FileInfo(configPath));
        }

        public static ILog GetInstance()
        {
            var log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            return log;
        }

        /// <summary>
        // 初始化
        // </summary>
        // <param name="configPath"></param>
        // <returns></returns>
        public static ILog GetInstance(string name)
        {
            var log = LogManager.GetLogger(name);
            return log;
        }
        
    }
}