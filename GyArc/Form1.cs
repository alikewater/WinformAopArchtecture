using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GS.Entlib.AOPHandler;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Diagnostics;
using GS.Entlib.Extension.Logging;
using Microsoft.Practices.Unity;
using GS.Entlib.Extension.Unity;
using TestBusinessLogic;

namespace GyArc
{
    public partial class Form1 : Form
    {
        private IUnityContainer container;
        IBusiness b ;
        BusinessObject obj ;
        public Form1()
        {
            InitializeComponent();

            container = new UnityContainer();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            EntlibConfigHelper.LoadUnityConfigFile(container, "", path + "unity.di.config");
            EntlibConfigHelper.LoadUnityConfigFile(container, "", path + "unity.aop.config");

            b = container.Resolve<IBusiness>();
            obj = new BusinessObject() { IValue = 12, SValue = "string12" };
        }

        private void btnUI_Click(object sender, EventArgs e)
        {
            //Exception ex = new Exception(Thread.CurrentThread.ManagedThreadId.ToString());

            //ExtraDebugInfoException extraEx = new ExtraDebugInfoException("extraInfo,"+"OriginInfo:"+ex.Message, ex);
            //throw extraEx;

            b.ExceptionTest("ExceptionTest");
        }

        private void btnUnhandle_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
                {
                    throw new Exception(Thread.CurrentThread.ManagedThreadId.ToString());
                });

            t.Start();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Logger.Write("Test", "Exception", 1, 100, TraceEventType.Error);
            Logger.Write("Test", "General", 1);
            
            
        }

        private void btnFormatter_Click(object sender, EventArgs e)
        {
            SimpleLogFormatter s = new SimpleLogFormatter(null);
            LogEntry le = new LogEntry();
            le.Severity = TraceEventType.Error;
            le.Message = "test";
            le.MachineName = "MyMachine";
             
            MessageBox.Show(s.Format(le));
        }

        private void btnAOP_Click(object sender, EventArgs e)
        {
            IBusiness b =  container.Resolve<IBusiness>();
            BusinessObject obj = new BusinessObject() {  IValue = 0,SValue="string12"};

            b.Insert(obj);

           
        }

        private void btnLock_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 100; i++)
            {
                Thread t = new Thread(NewMethod);
                t.Start(); 
            }

        }

        private void NewMethod()
        { 
            b.Insert(obj);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string res = string.Join( "|",b.LinkTest()); 

            MessageBox.Show(res);
        }

        
    }
}
