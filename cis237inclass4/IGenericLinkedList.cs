using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    interface IGenericLinkedList<T> // the <> Allow us to define the type to make it generic; Type [T] is the .net standard for defining generic T EX: <A, B, C> defines several types
    {
        void Display();

        void AddToFront(T Data);

        void AddToBack(T Data);

        T RemoveFromFront();

        T RemoveFromBack();

        bool IsEmpty { get; }
        int Size { get; }
    }
}
