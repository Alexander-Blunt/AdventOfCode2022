using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11App
{
    public class Monkey
    {
        public Queue<int> Items { get; set; }
        public Func<int, int> Operation { get; }
        public Func<int, bool> Test { get; }
        public Monkey TrueReceiver { get; }
        public Monkey FalseReceiver { get; }

        public Monkey(Queue<int> startingItems, Func<int, int> operation, Func<int, bool> test, Monkey trueReceiver, Monkey falseReceiver)
        {
            Items = startingItems;
            Operation = operation;
            Test = test;
            TrueReceiver = trueReceiver;
            FalseReceiver = falseReceiver;
        }

        public void TakeTurn()
        {
            while (Items.Count > 0)
            {
                int worryLevel = Items.Dequeue();
                worryLevel = Operation(worryLevel);
                worryLevel /= 3;
                if (Test(worryLevel)) TrueReceiver.Catch(worryLevel);
                else FalseReceiver.Catch(worryLevel);
            }
        }

        private void Catch(int worryLevel) => Items.Enqueue(worryLevel);
    }
}
