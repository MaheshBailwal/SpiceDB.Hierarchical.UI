using Serilog;
using Serilog.Core;

namespace SpiceDB.UI
{
    internal static class Program
    {
        static Logger _logger;
      
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            _logger = new LoggerConfiguration()
                    .WriteTo.File("SpiceDbUILog.txt")
                    .CreateLogger();

            ApplicationConfiguration.Initialize();
            Application.Run(new MainFrm());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
            LogError(e.Exception);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            MessageBox.Show(e.Message, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
            LogError(e);
        }

        private static void LogError(Exception exception)
        {
            _logger.Error(exception.ToString());
        }
    }
}