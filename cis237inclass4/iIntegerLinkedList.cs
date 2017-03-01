using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    interface iIntegerLinkedList
    {
        void AddMaintainSort(int IntegerData);

        int RemoveMaintinaSort(int RemoveData);

        void Display();

        bool IsEmpty { get; }
        int Size { get; }
    }
}
