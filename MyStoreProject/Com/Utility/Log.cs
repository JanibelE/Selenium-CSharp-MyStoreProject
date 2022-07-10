

using log4net;
using log4net.Config;

namespace MyStoreProject.Com.Utility
{
    public class Log
    {


        // Initialize Log4j logs
        private static ILog _Log;

        //public Log(Type type)
        //{
        //    _Log = LogManager.GetLogger(type);
        //}

        public static ILog SetLogType(Type type)
        {
            return _Log = LogManager.GetLogger(type);
        }
	    public static void startTestCase(String sTestCaseName)
        {
			//var s=XmlConfigurator.Configure(new FileInfo("log4j.xml"));
            _Log.Info("=====================================" + sTestCaseName + " TEST START=========================================");
        }

        public static void endTestCase(String sTestCaseName)
        {
            _Log.Info("=====================================" + sTestCaseName + " TEST END=========================================");
        }

        // Need to create below methods, so that they can be called  

        public static void info(String message)
        {

            _Log.Info(message);

        }

        public static void warn(String message)
        {

            _Log.Warn(message);

        }

        public static void error(String message)
        {

            _Log.Error(message);

        }

        public static void fatal(String message)
        {

            _Log.Fatal(message);

        }

        public static void debug(String message)
        {

            _Log.Debug(message);

        }
        public static ILog GetXmlLogget(Type type)
        {
            if (_Log != null)
                return _Log;

            XmlConfigurator.Configure();
            _Log = LogManager.GetLogger(type);

            return _Log;

        }
    }
}
