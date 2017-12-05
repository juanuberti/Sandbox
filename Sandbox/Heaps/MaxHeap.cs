using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Heaps
{
    public class MaxHeap
    {
        public int Capacity { get; set; }
        public int Size { get; set; }

        public int[] Items { get; set; }

        public MaxHeap(int capacity)
        {
            this.Capacity = capacity;
            Items = new int[Capacity];
        }

        public int GetLeftIndex(int parentIndex) { return 2 * parentIndex + 1; }
        public int GetRightIndex(int parentIndex) { return 2 * parentIndex + 2; }
        public int GetParentIndex(int childIndex) { return (childIndex - 1) / 2; }

        public bool HasLeftChild(int parentIndex) { return GetLeftIndex(parentIndex) < Size; }
        public bool HasRightChild(int parentIndex) { return GetRightIndex(parentIndex) < Size; }
        public bool HasParent(int childIndex) { return GetParentIndex(childIndex) >= 0; }

        public int LeftChild(int index) { return Items[GetLeftIndex(index)]; }
        public int RightChild(int index) { return Items[GetRightIndex(index)]; }
        public int Parent(int index) { return Items[GetParentIndex(index)]; }

        public void Swap(int index1, int index2)
        {
            int temp = Items[index1];
            Items[index1] = Items[index2];
            Items[index2] = temp;
        }

        public void EnsureExtraCapacity()
        {
            if (Size == Capacity)
            {
                Capacity *= 2;
                int[] newHeap = new int[Capacity];
                Items.CopyTo(newHeap, 0);
                Items = newHeap;
            }
        }

        public int Peek()
        {
            if (Size == 0)
            {
                throw new NullReferenceException();
            }
            else
                return Items[0];
        }

        public int Poll()
        {
            if (Size == 0)
            {
                throw new NullReferenceException();
            }
            else
            {
                Swap(0, Size - 1); //swap the first and last items on the array. Since the size gets reduced on the next operation, the original head is functionally deleted.
                Size--;
                //Reform the Heap. The Head, now at an inaccessible address, will not be affected by this.
                HeapifyDown();
                return Items[Size - 1];
            }
        }

        public void Add(int item)
        {
            EnsureExtraCapacity();
            Size++;
            Items[Size - 1] = item;
            HeapifyUp();
        }

        public void HeapifyUp()
        {
            int index = Size - 1;
            while (HasParent(index) && Items[GetParentIndex(index)] < Items[index])
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        public void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int largerChildIndex = GetLeftIndex(index);

                if (HasRightChild(index) && Items[GetRightIndex(index)] > Items[largerChildIndex])
                    largerChildIndex = GetRightIndex(index);

                if (Items[index] > Items[largerChildIndex])
                    break;

                else
                {
                    Swap(index, largerChildIndex);
                }
                index = largerChildIndex;
            }
        }

    }
}
