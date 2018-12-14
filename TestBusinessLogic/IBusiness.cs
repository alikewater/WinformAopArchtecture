using MyDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TestBusinessLogic
{
    public interface IBusiness
    {
        int Insert(int a);

        BusinessObject Insert(BusinessObject obj);

        int Delete(int a);

        void ExceptionTest(string test);

        List<bool> LinkTest();
         
    }

    public class BusinessImp : IBusiness
    {
        public int Insert(int a)
        {
            Console.WriteLine("Insert int a");
            return a;
        }

        public BusinessObject Insert(BusinessObject obj)
        {
            Console.WriteLine("Insert BusinessObject obj");
            Console.WriteLine(obj.IValue++);
            return obj;
        }

        public int Delete(int a)
        {
            Console.WriteLine("Delete int a");
            return a;
        }


        public void ExceptionTest(string test)
        {
            throw new NotImplementedException();
        }

        public List<bool> LinkTest()
        {
            List<bool> res = new List<bool>();

            object obj =  
                 Activator.CreateInstance(typeof(TestBusinessLogic.BusinessImp));

            bool res01 = (bool)typeof(BusinessImp).InvokeMember("LinkTestInner", BindingFlags.InvokeMethod, null, obj, null);

            bool res02 = (bool)typeof(BusinessImp).InvokeMember("LinkTestInner2", BindingFlags.InvokeMethod, null, obj, null);

            res.Add(res01);
            res.Add(res02);

            return res;
        }

        public bool LinkTestInner()
        {
            MyDc dc = new MyDc();
            bool res = false;
            try
            {

                dc.Connection.Open();
                Console.WriteLine(dc.Connection.State.ToString());
                dc.Connection.Close();

                res = true;
                return res;
            }
            catch
            {
                return false;
            }
            
        }

        public bool LinkTestInner2()
        {
            MyDc2 dc = new MyDc2();
            bool res = false;
            try
            {
             
                dc.Connection.Open();
                Console.WriteLine(dc.Connection.State.ToString());
                dc.Connection.Close();

                res = true;
                return res;
            }
            catch
            {
                
                return false;
            }

        }
    }
}
