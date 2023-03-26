using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Exception;
using static System.Console;

namespace InterfacesWPU221
{
    //1 способ создания своего исключения - создание класса, описывающего наше исключение
    /*public class MyException : ApplicationException
    {
        private string _message;
        public DateTime TimeException { get; private set; }
        public MyException()
        {
            _message = "Мое исключение";
            TimeException = DateTime.Now;
        } 
        //во 2 способе переопределение свойства Message не требуется, используем вызов конструктора базового класса с указанием уникального сообщения
        public MyException() : base("Мое исключение")
        {
            TimeException = DateTime.Now;
        }
        //в первом способе переопределяется свойство базового класса для вывода уникального сообщения нашего исключения
        public override string Message
        {
            get { return _message; }
        }
    }*/

    //3 способ. Пишем Exception, нажимаем 2 раза Tab

    /*[Serializable]
    public class MyException1 : Exception
    {
        public DateTime TimeException { get; private set; }
        public MyException1():base("Мое исключение") {
            TimeException = DateTime.Now;
        }
        public MyException1(string message) : base(message) { }
        public MyException1(string message, Exception inner) : base(message, inner) { }
        protected MyException1(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }*/

    //синтаксис  try-catch-finally
    /*
    try{
        //код, в котором может возникнуть исключение
    }
    catch (тип_исключения)
    {
        //обработка исключения
    }
    finally
    {
        //освобождение ресурсов
    }*/

    class Exceptions
    {
        static void Main(string[] args)
        {
            try//внешний блок
            {
                //код А
                try//внутренний блок
                {
                    //код B
                }
                catch
                {
                    //код C
                }
                finally
                {
                    //очистка
                }
                //код D
            }
            catch
            {
                //обработка ошибок
            }
            finally
            {
                //очистка
            }
        }
    }
}