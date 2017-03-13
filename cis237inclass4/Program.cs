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
            // example of built in linked list LinkedList<[Type]>;
            linkedList.AddMaintainSort(5);
            linkedList.AddMaintainSort(3);
            linkedList.AddMaintainSort(4);
            linkedList.AddMaintainSort(2);
            linkedList.AddMaintainSort(1);
            linkedList.Display();

            linkedList.RemoveMaintinaSort(3);
            linkedList.RemoveMaintinaSort(1);
            linkedList.Display();

            linkedList.AddToFront(100);
            linkedList.AddToBack(100);
            linkedList.Display();

            linkedList.RemoveFromBack();
            linkedList.RemoveFromFront();
            linkedList.Display();

            // instantiate a new instance of generic linked list 
            // this instance will hold string primitive types
            IGenericLinkedList<string> StringGenericLL = new GenericLinkedList<string>();
            // create a new instance to hold ints
            IGenericLinkedList<int> IntGenericLL = new GenericLinkedList<int>();
            // how about on to hold the built in class linked list
            // not sure if you would ever do this, but here it is to see that you can do it
            IGenericLinkedList<LinkedList<int>> InceptionLL = new GenericLinkedList<LinkedList<int>>();
            StringGenericLL.AddToFront("Sherman");
            StringGenericLL.AddToFront("Wayne");
            StringGenericLL.AddToFront("Kyle");
            StringGenericLL.Display();
            StringGenericLL.RemoveFromBack();
            StringGenericLL.RemoveFromBack();
            StringGenericLL.Display();
            StringGenericLL.AddToBack("Wayne");
            StringGenericLL.AddToBack("Sherman");
            StringGenericLL.Display();
        }
    }
}
