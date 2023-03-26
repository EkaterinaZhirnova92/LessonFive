using System;
using System.Collections; //подключаем для работы стандартных интерфейсов
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
namespace StandartInterface
{
    class StudentCard
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public override string ToString()
        {
            return $"Студенческий билет: {Series} {Number}\n";
        }
    }

    class Student : IComparable
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string group { get; set; }
        public StudentCard StudentCard { get; set; }

        public override string ToString()
        {
            return $"Имя: {firstName}\nФамилия: {lastName}\nДата рождения: {birthDate.ToLongDateString()}\nФакультет: {group}\n" + StudentCard.ToString();
        }

        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                return lastName.CompareTo((obj as Student).lastName);
            }
            throw new NotImplementedException();
        }
    }

    class Auditory : IEnumerable
    {
        Student[] students =
        {
            new Student
            {
                firstName="Harry",
                lastName="Potter",
                birthDate=new DateTime(1981,07,31),
                group="Griffindor",
                StudentCard=new StudentCard
                {
                    Number=19810731,
                    Series="HP"
                }
            },
            new Student
            {
                firstName="Drako",
                lastName="Malfoy",
                birthDate=new DateTime(1981,10,23),
                group="Slitherin",
                StudentCard=new StudentCard
                {
                    Number=19811023,
                    Series="DM"
                }
            },
            new Student
            {
                firstName="Polumna",
                lastName="Lovegood",
                birthDate=new DateTime(1985,03,15),
                group="Hufflepuff",
                StudentCard=new StudentCard
                {
                    Number=19850315,
                    Series="PL"
                }
            },
            new Student
            {
                firstName="Cedrick",
                lastName="Diggory",
                birthDate=new DateTime(1980,09,25),
                group="Ravenclaw",
                StudentCard=new StudentCard
                {
                    Number=19800925,
                    Series="CD"
                }
            }
        };

        public void Sort()
        {
            Array.Sort(students);
        }

        public void Sort(IComparer comparer)
        {
            Array.Sort(students, comparer);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return students.GetEnumerator();
        }
    }

    class DataComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return DateTime.Compare((x as Student).birthDate, (y as Student).birthDate);
            }
            throw new NotImplementedException();
        }
    }

    class StandartInterface
    {
        static void Main(string[] args)
        {
            Auditory auditory = new Auditory();
            WriteLine("************Список студентов*****************");
            WriteLine();
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }
            WriteLine("***********Сортировка по фамилии************");
            WriteLine();
            auditory.Sort();
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }

            WriteLine("***********Сортировка по дате рождения************");
            WriteLine();
            auditory.Sort(new DataComparer());
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }
        }
    }
}