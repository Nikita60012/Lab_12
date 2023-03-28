using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventHandling first = new EventHandling("FirstObject");
            EventHandling second = new EventHandling("SecondObject");
            TextArgs textArgs = new TextArgs("Args");
            first.Notify += textArgs.showStr;
            second.Notify += textArgs.showStr;
            first.EventGenerate();
            second.EventGenerate();
        }
        class EventHandling
        {
            public string Name { get; }
            public EventHandling(string name) {
                Name = name;
            }

            public delegate void EventHandler(string str);
            public event EventHandler Notify;
            public void EventGenerate()
            {
                if(Notify != null)
                {
                    Notify(Name);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
        class TextArgs
        {
            string message;
            public TextArgs(string txt)
            {
              this.message = txt;
            }
            public void showStr(string generator)
            {
                Console.WriteLine("Кто сгенерировал: " + generator);
                Console.WriteLine("Переданное сообщение: " + message);
            }
        }
    }
}
