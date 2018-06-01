using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GyArc
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            //异常处理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.Run(new Form1());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                Exception ex = e.ExceptionObject as Exception;
                Handle_Exception(ex, "Unhandle Policy"); 
            }
 
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Handle_Exception(e.Exception, "UI Policy");
        }


        private static void Handle_Exception(Exception ex, string policy)
        {
            bool rethrow = false; // 一般异常需要传达一些具体信息给用户，特殊异常只能笼统的给出一个提示

            try
            {
                rethrow = HandleExByPolicy(ex, policy);
            }
            catch (Exception innerEx)
            {
                string errorMsg = "处理异常过程中出现异常";
                
                errorMsg = errorMsg + "\n" + innerEx.Message;
                MessageBox.Show(errorMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
               
            }

            if (rethrow)//可分析的异常，提醒用户错误信息较为详细
            {
                string msg = ex.Message;
                MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else//其他异常，采用简单的提示
            {
                MessageBox.Show("已经记录了一个未能处理的异常", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private static bool HandleExByPolicy(Exception ex, string policy)
        {
            Console.WriteLine(ex.Message);

            Console.WriteLine(ex.StackTrace.ToString());

            return ExceptionPolicy.HandleException(ex, policy);
           
        }
    }
}
