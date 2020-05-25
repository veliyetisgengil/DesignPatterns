using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SingletonDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = Car.Instance("BMV",2);
            Car car2 = Car.Instance("Mercedes", 3);

            Console.Write("Car 1 Model: " + car1.Model);
            Console.WriteLine("Car 2 Model: " + car2.Model);
            Console.ReadLine();

            //Output
            /*
             Car 1 Model : BMV
             Car 2 Model : BMV
             */
        }
    }
    public class Car  
    {
        private static  Car car;
        public string Model { get; set; }
        public int Year { get; set; }
        private Car() 
        {
        
        }
        private Car(string Model, int Year) 
        {
            this.Model = Model;
            this.Year = Year;
        }
        private static object lockObject = new object();

        public static Car Instance(string Model,int Year) 
        {
            if (car == null) 
            {
                lock(lockObject)
                {
                    if (car == null) 
                    {
                        car = new Car(Model,Year);
                    }
                }
            }
            return car;
        }
    

    }
    
 

}
