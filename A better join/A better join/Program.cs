using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace A_better_join
{
    internal class Program
    {

        static string JoinWithAnd(List<string> items, bool useSerialComma = true)
        {
            int count = items.Count;
            if (count == 0)
            {
                return String.Join("", items);

            }
            else if (count == 1)
            {
                return items[0];
            }
            else if (count == 2)
            {
                return String.Join(" and ", items);
            }
            else
            {
                var itemsCopy = new List<string>(items);

                if (useSerialComma == true)
                {
                    itemsCopy[count - 1] = "and " + itemsCopy[count - 1];
                    return String.Join(", ", itemsCopy);
                }
                else
                    {
                    itemsCopy[count - 2] += " and " + itemsCopy[count - 1];
                    itemsCopy.RemoveAt(count - 1);
                    return String.Join(", ", itemsCopy);
                }
            }
        }
        static void Main(string[] args)
        {
            var itemsInList = new List<string>();
            itemsInList.Add("A");
            itemsInList.Add("B");
            itemsInList.Add("C");
            itemsInList.Add("D");
            itemsInList.Add("E");
            itemsInList.Add("F");
            Console.WriteLine(JoinWithAnd(itemsInList,false));
            Console.ReadLine();
        }
    }
}
