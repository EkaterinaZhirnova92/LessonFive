using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


//синтаксис интерфейса
//[модификатор доступа] interface имя_интерфейса (с заглавн буквы I)
//{
//    члены интерфейса
//}
namespace LessonFive
{
    public interface IWorker
    {
        //event EventHandler WorkEnded;
        bool IsWorking { get; }
        string Work();
    }

    public interface IManager
    {
        List<IWorker> ListOfWorkers { get; set; }
        void Organize();
        void MakeBudget();
        void Control();

    }

    abstract class Human
    {
        public string _firstName { get; set; }
        public string _lastName { get; set; }
        public DateTime _birtdate { get; set; }
        public override string ToString()
        {
            return $"Имя: {_firstName}\nФамилия: {_lastName}\nДата рождения: {_birtdate.ToShortDateString()}\n";
        }
    }

    abstract class Employee : Human
    {
        public string _position { get; set; }
        public double _salary { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Должность: {_position}\nЗарплата: {_salary}\n";
        }

    }

    class Director : Employee , IManager
    { 
        public List<IWorker> ListOfWorkers { get; set; }
        public void Organize()
        {
            WriteLine("Я организую работу магазина и сторудников");
        }
        public void MakeBudget()
        {
            WriteLine("Я формирую бюджет");
        }
        public void Control()
        {
            WriteLine("Я контролирую работу магазина и сотрудников");
        }
    }

    class Seller : Employee, IWorker
    {
        public bool isWorking = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }
        public string Work()
        {
            return "Я продаю товар";
        }
    }

    class Cashier : Employee, IWorker
    {
        public bool isWorking = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }
        public string Work()
        {
            return "Я принимаю оплату за товар";
        }
    }

    class Storekeeper : Employee, IWorker
    {
        public bool isWorking = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }
        public string Work()
        {
            return "Я принимаю и учитываю товар";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director
            {
                _firstName = "Ray",
                _lastName = "Crock",
                _birtdate = new DateTime(1945, 12, 12),
                _position = "Director",
                _salary = 300000
            };

            IWorker seller = new Seller
            {
                _firstName = "JimRay",
                _lastName = "Seller",
                _birtdate = new DateTime(1988, 11, 05),
                _position = "Seller",
                _salary = 30000
            };

            if (seller is Employee)
            {
                WriteLine($"Заработная плата продавца: {(seller as Employee)._salary}");
            }

            director.ListOfWorkers = new List<IWorker>
            {
                seller,
                new Cashier
                {
                    _firstName = "Elena",
                    _lastName = "Smirnova",
                    _birtdate = new DateTime(1992, 12, 12),
                    _position = "Cashier",
                    _salary = 35000
                },
                new Storekeeper
                {
                    _firstName = "Albert",
                    _lastName = "Sidorov",
                    _birtdate = new DateTime(1993, 01, 12),
                    _position = "Storekeeper",
                    _salary = 15000
                }
            };

            WriteLine(director);
            if (director is IManager)
            {
                director.Control();
            }

            foreach (IWorker item in director.ListOfWorkers)
            {
                WriteLine(item);
                if (item.IsWorking)
                {
                    WriteLine(item.Work());
                }
            }
        }
    }
}
