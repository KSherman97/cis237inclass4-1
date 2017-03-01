using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class IntegerLinkedList : iIntegerLinkedList
    {
        public void AddMaintainSort(int IntegerData) 
        {
            Node newNode = new Node(); // make a new node
            newNode.Data = IntegerData; // assign the passed in data to it

            // check to see if the list is empty, or the node we
            // are adding is less than the current head.
            if(IsEmpty || _head.Data >= newNode.Data)
            {
                newNode.Next = _head; // set the newNode's next property to the head pointer
                _head = newNode; // set the head pointer to the new node

                // if the tail is null the reassign the tail to the head pointer location
                if (_tail == null)
                {
                    _tail = _head;
                }
            }
            // else we want to add a node toa list that is not empty and the node we want to add is 
            // at least after the first node
            else
            {
                // set up a node pointer to walk throught the list
                Node currentNode = _head;

                // linear search to find the correct spot
                while(currentNode.Next != null && currentNode.Next.Data < newNode.Data)
                {
                    // se the current node to currentNode's next node
                    currentNode = currentNode.Next;

                }

                // Make the newNode's next property point to the
                // current nodes Next property
                newNode.Next = currentNode.Next;
                // set the currentNodes next to the new node
                currentNode.Next = newNode;

                // check to see if the tail was the same as the currentnode
                // if it is, the current node was the tail, but it is no longer.
                // now the new node has become the tail, so we need to move that
                // tail pointer 
                if(_tail == currentNode)
                {
                    _tail = newNode;
                }

                // increment the size
                _size++;
            }
        }

        public int RemoveMaintinaSort(int RemoveData) {

            // if empty throw exception
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }

            int returnData;

            // if the head and tail point to the same place
            // or if the data in the head is the data we want to remove
            if(_head == _tail || _head.Data == RemoveData)
            {
                // set the return data
                returnData = _head.Data;
                // make the head point to the head node's next node
                _head = _head.Next;

                if(_head == null)
                {
                    _tail = null;
                }
            }
            else // else we are removing somewhere past the first node
            {
                // make a currentNode pointer to walk the list
                Node currentNode = _head;

                // while we are not at the end of the lis and the current
                // node data is not what we want to remove
                while(currentNode.Next != _tail &&
                    currentNode.Next.Data != RemoveData)
                {
                    currentNode = currentNode.Next;
                }


                // if the currentNode's next node's data is what 
                // I want to remove, let's remove it
                if(currentNode.Next.Data == RemoveData)
                {
                    // sincec it's what we want, lets set it
                    returnData = currentNode.Next.Data;

                    // if the currentNode's next node is the tail
                    // we want to set the tail to the current node
                    if(currentNode.Next == _tail)
                    {
                        _tail = currentNode;
                    }

                    // need to set the current node's next property
                    // to the current node's next node's next
                    // skipping over the one we are removing. 
                    currentNode.Next = currentNode.Next.Next;

                }
                // else we want all the way to the end without finding it,
                // so throw and exception
                else
                {
                    throw new Exception("item not found");
                }
            }
            //decrement the size
            _size--;

            // return the return data 
            return returnData;
        }

        // this is a big O of 1 --- O(1)
        public void AddToFront(int integerData)
        {
            // make a new variable to also reference the head ofthe list
            Node oldHead = _head;

            // make a new node and assign it to the head variable
            _head = new Node();

            // set the data on the new node
            _head.Data = integerData;

            // make the next property of the new node point o the old head
            _head.Next = oldHead;

            // increment the size of the list
            _size++;

            // ensure that if we are adding the very first node to the list 
            // that the tail will be pointing to the new node we create
            if(_size == 1)
            {
                _tail = _head;
            }
        }


        // this is a big O of 1 --- O(1)
        public void AddToBack(int integerData)
        {
            // make a pointer to the tail called old tail
            Node oldTail = _tail;

            // assign the tail to a new node
            _tail = new Node();

            // assign the passed in data to the tail
            _tail.Data = integerData;

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
        public int RemoveFromFront()
        {
            // if it is empty throw an error
            if (IsEmpty)
                throw new Exception("list is empty");

            // let's get the data to return
            int returnData = _head.Data;

            // move the head pointer to the next in the list.
            _head = _head.Next;

            //decrease the size
            _size--;

            // check to see if we just removed the last node from the list
            if(IsEmpty)
            {
                _tail = null;
            }

            // return the return data we pulled out from the first node
            return returnData;
        }

        // remove from the back is not as easy. It requires more work
        // this has a big O of  O()
        public int RemoveFromBack()
        {
            // check for empty, throw exception if it is
            if (IsEmpty)
                throw new Exception("list is empty");

            // get the return data right off the bat
            int returnData = _tail.Data;

           // _tail = _tail.Last;

            // decrease the size
            _size--;


            // check to see if we are on the last node
            // if so, we can just set the head and tail to null since we want 
            // to remove the only node remaining in the list
            if(_head == _tail)
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
                while(current.Next != _tail)
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
            while(currentNode != null)
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
            public int Data { get; set; }
            public Node Next { get; set; }

            public Node Last { get; set; }
        }
    }
}