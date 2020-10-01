using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var doubleList = new DoublyLinkedList<string>();

            doubleList.AddLast("string");
            doubleList.AddLast("1234");
            doubleList.AddLast("3565");
            doubleList.AddLast("test");

            foreach (var item in doubleList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
