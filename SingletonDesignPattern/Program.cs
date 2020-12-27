using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SingletonDesignPattern
{
    public class Toyota
    {
        private Toyota()
        {

        }
        public static Toyota obj;

        private static readonly object mylockobject = new object();
       public static Toyota GetInstance()
        {
            lock (mylockobject)
            {
                if (obj == null)
                {
                    obj = new Toyota();
                }
               
            }
            return obj;
        }
        public string getDetails()
        {
            return "India";
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            //Toyota toy = Toyota.GetInstance();
            //Toyota toy1 = Toyota.GetInstance();
            //string x = toy.getDetails();
            //Console.WriteLine(x);
            //Console.ReadLine();
            IcarSupplier objcarsupplier = Carfactory.getcarIntance(1);
            objcarsupplier.GetcarModel();
            Console.WriteLine(objcarsupplier.color);

        }
    }




    #region factory design pattern

    public interface IcarSupplier
    {
        string color
        {
            get;
        }
        void GetcarModel();
    }
    public class BMW : IcarSupplier
    {
        public string color
        {
            get
            {
                return "BMW2020";
            }
        }

        public void GetcarModel()
        {
            Console.WriteLine("Bmw car color is white blue");
        }
    }
    public class Honda : IcarSupplier
    {
        public string color
        {
            get
            {
                return "Black red";
            }
        }

        public void GetcarModel()
        {
            Console.WriteLine("Honda 2020");
        }
    }

    public class Nano : IcarSupplier
    {
        public string color
        {
            get
            {
                return "Blue";
            }
        }

        public void GetcarModel()
        {
            Console.WriteLine("Nano 20204");
        }
    }
     static class Carfactory
    {
      public   static IcarSupplier getcarIntance(int id)
        {
            switch (id)
            {
                case 0:
                    return new BMW();
                case 1:
                    return new Nano();
                case 2: return new Honda();
                default:return null;
            }
        }
    }


    #endregion


    public class Connection
    {
        SqlCommand cmd;
        DataSet ds;
        DataTable _dt;
        SqlDataAdapter da;

       private Connection()
        {

        }
        public static Connection obj=null;
        private static readonly object mylockobject = new object();
        public static Connection getIntance()
        {
            lock (mylockobject)
            {
                if (obj == null)
                {
                    obj = new Connection();
                }
            }
            return obj;
        }
    }
}
