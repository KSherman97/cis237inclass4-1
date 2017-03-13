using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class GenericLinkedList<T> : IGenericLinkedList<T>
    {
        // this is a big O of 1 --- O(1)
        public void AddToFront(T Data)
        {
            // make a new variable to also reference the head ofthe list
            Node oldHead = _head;

            // make a new node and assign it to the head variable
            _head = new Node();

            // set the data on the new node
            _head.Data = Data;

            // make the next property of the new node point o the old head
            _head.Next = oldHead;

            // increment the size of the list
            _size++;

            // ensure that if we are adding the very first node to the list 
            // that the tail will be pointing to the new node we create
            if (_size == 1)
            {
                _tail = _head;
            }
        }


        // this is a big O of 1 --- O(1)
        public void AddToBack(T Data)
        {
            // make a pointer to the tail called old tail
            Node oldTail = _tail;

            // assign the tail to a new node
            _tail = new Node();

            // assign the passed in data to the tail
            _tail.Data = Data;

            // set the next node to null
            _tail.Next = null;

            //_size++;


            // check to see if the list is empty. If so, make the tail 
            // point to the same location as the tail.
            if (IsEmpty)
            {
                _head = _tail;
            }

            // we need to take the oldtail and make it's next property
            // point to the tail that we just created
            else
            {
                oldTail.Next = _tail;
            }

            // increment the size
            _size++;
        }

        // this is a big O of 1 --- O(1)
        public T RemoveFromFront()
        {
            // if it is empty throw an error
            if (IsEmpty)
                throw new Exception("list is empty");

            // let's get the data to return
            T returnData = _head.Data;

            // move the head pointer to the next in the list.
            _head = _head.Next;

            //decrease the size
            _size--;

            // check to see if we just removed the last node from the list
            if (IsEmpty)
            {
                _tail = null;
            }

            // return the return data we pulled out from the first node
            return returnData;
        }

        // remove from the back is not as easy. It requires more work
        // this has a big O of  O()
        public T RemoveFromBack()
        {
            // check for empty, throw exception if it is
            if (IsEmpty)
                throw new Exception("list is empty");

            // get the return data right off the bat
            T returnData = _tail.Data;

            // _tail = _tail.Last;

            // decrease the size
            _size--;


            // check to see if we are on the last node
            // if so, we can just set the head and tail to null since we want 
            // to remove the only node remaining in the list
            if (_head == _tail)
            {
                _head = null;
                _tail = null;
            }
            // else, we need to traverse the list and stop right vefore we 
            // reach the tail
            else
            {
                // create a temp node to use the 'walk down the list'
                Node current = _head;
                while (current.Next != _tail)
                {
                    // set the current pointer to the current pointer's next
                    // node
                    current = current.Next;
                }

                // I am now in a position to do some work
                // set the tail to the current position
                _tail = current;

                // make the last node that we are removing go away by setting tail's next property to null
                _tail.Next = null;
            }

            return returnData;

        }

        public void Display()
        {
            Console.WriteLine("The list is: ");
            // setup a currentnode to walk the list 
            // start it at the head node
            Node currentNode = _head;

            // loop through the nodes until we hit a null
            // which will signify the end of the list
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Data);
                // move to the next node
                currentNode = currentNode.Next;
            }
            Console.WriteLine("end " + Environment.NewLine);
        }

        // if the first index is null then it's empty
        // to check whether or not it is empty we can
        // check to see if the head pointer is null. 
        // if so, then there are no nodes in the list 
        // so it must be empty
        public bool IsEmpty { get { return _head == null; } }

        public int Size { get; }

        protected Node _head; // beginning index
        protected Node _tail; // last index
        protected int _size; // size of the linked list

        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node Last { get; set; }
        }
    }
}