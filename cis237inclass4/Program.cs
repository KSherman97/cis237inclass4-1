using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class Program
    {
        static void Main(string[] args)
        {
            iIntegerLinkedList linkedList = new IntegerLinkedList();

            linkedList.AddMaintainSort(5);
            linkedList.AddMaintainSort(3);
            linkedList.AddMaintainSort(4);
            linkedList.AddMaintainSort(2);
            linkedList.AddMaintainSort(1);

            linkedList.Display();

            linkedList.RemoveMaintinaSort(3);
            linkedList.RemoveMaintinaSort(1);

            linkedList.Display();
        }
    }
}
