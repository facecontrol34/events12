using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awertfdf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            First firstObject1 = new First("Объект первого 1");
            First firstObject2 = new First("Объект первого 2");
            Second secondObject = new Second();


            firstObject1.MyEvent += secondObject.HandleEvent;
            firstObject2.MyEvent += secondObject.HandleEvent;

            firstObject1.GenerateEvent();
            firstObject2.GenerateEvent();
        }
    }
    class First
    {
        public delegate void Event(string name);
        public event Event MyEvent;
        public string name;

        public First(string name)
        {
            this.name = name;
        }
        public void GenerateEvent()
        {
            if (MyEvent != null)
            {
                MyEvent.Invoke(name);
            }
        }
    }

    class Second
    {
        public void HandleEvent(string eventName)
        {
            Console.WriteLine("Событие было сгенерировано: " + eventName);
        }
    }
}
