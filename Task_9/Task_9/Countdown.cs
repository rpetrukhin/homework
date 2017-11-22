using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_9
{
    public class TimerEndsEventArgs : EventArgs
    {
        public readonly string Message;

        public TimerEndsEventArgs(string message)
        {
            Message = message;
        }
    }

    public class Countdown
    {
        public delegate void TimerEndsEventHandler(TimerEndsEventArgs e);

        public event TimerEndsEventHandler TimerEnds;

        protected virtual void OnTimerEnds(TimerEndsEventArgs e)
        {
            TimerEnds?.Invoke(e);
        }

        public void Sleep(int time, string message)
        {
            Thread.Sleep(time);
            OnTimerEnds(new TimerEndsEventArgs(message));
        }
    }

    public class Subscriber1
    {
        public void Subscribe(Countdown countdown)
        {
            countdown.TimerEnds += PrintMessage;
        }

        public void Unsubscribe(Countdown countdown)
        {
            countdown.TimerEnds -= PrintMessage;
        }

        private void PrintMessage(TimerEndsEventArgs e)
        {
            Console.WriteLine("Subscriber1 get message: "+ e.Message);
        }
    }

    public class Subscriber2
    {
        public void Subscribe(Countdown countdown)
        {
            countdown.TimerEnds += PrintMessage;
        }

        public void Unsubscribe(Countdown countdown)
        {
            countdown.TimerEnds -= PrintMessage;
        }

        private void PrintMessage(TimerEndsEventArgs e)
        {
            Console.WriteLine("Subscriber2 get message: " + e.Message);
        }
    }

    public class CountdownTest
    {
        public static void Main(string[] args)
        {
            Countdown countdown = new Countdown();

            Subscriber1 subscriber1 = new Subscriber1();
            Subscriber2 subscriber2 = new Subscriber2();

            subscriber1.Subscribe(countdown);
            subscriber2.Subscribe(countdown);

            countdown.Sleep(3000, "Hello, subscribers!");

            subscriber2.Unsubscribe(countdown);

            countdown.Sleep(3000, "What's new?");
        }
    }
}