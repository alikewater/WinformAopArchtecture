using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestBusinessLogic
{
    public interface IBusiness
    {
        int Insert(int a);

        BusinessObject Insert(BusinessObject obj);

        int Delete(int a);

        void ExceptionTest(string test);
         
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
    }
}
