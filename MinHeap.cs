public class MinHeap
{
    public int[] heap;
    private int size;
    public MinHeap(int capacity)
    {
        heap = new int[capacity];
        size = 0;
    }

    public int Parent(int index)
    {
        return (index - 1) / 2;
    }

    public int[] Children(int index)
    {
        int leftChild = 2 * index + 1;
        int rightChild = 2 * index + 2;
        int[] children = new int[2];

        if (leftChild < size)
            children[0] = heap[leftChild];
        else
            children[0] = -1;

        if (rightChild < size)
            children[1] = heap[rightChild];
        else
            children[1] = -1;

        return children;
    }

    private void SiftUp(int index)
    {
        int parentIndex = Parent(index);

        while (index > 0 && heap[index] < heap[parentIndex])
        {
            Swap(index, parentIndex);
            index = parentIndex;
            parentIndex = Parent(index);
        }
    }

    private void SiftDown(int index)
    {
        int minChildIndex = GetMinChildIndex(index);

        while (minChildIndex != -1 && heap[index] > heap[minChildIndex])
        {
            Swap(index, minChildIndex);
            index = minChildIndex;
            minChildIndex = GetMinChildIndex(index);
        }
    }

    private int GetMinChildIndex(int index)
    {
        int leftChild = 2 * index + 1;
        int rightChild = 2 * index + 2;

        if (leftChild >= size)
            return -1;

        if (rightChild >= size)
            return leftChild;

        return heap[leftChild] < heap[rightChild] ? leftChild : rightChild;
    }

    public void BuildHeap(int[] array)
    {
        if (array.Length > heap.Length)
            throw new ArgumentException("Емкость превышена");

        heap = array;
        size = array.Length;

        for (int i = Parent(size - 1); i >= 0; i--)
        {
            SiftDown(i);
        }
    }

    public int ExtractMin()
    {
        if (size == 0)
            throw new InvalidOperationException("Куча пустая");

        int min = heap[0];
        heap[0] = heap[size - 1];
        size--;
        SiftDown(0);
        return min;
    }

    public void Insert(int value)
    {
        if (size == heap.Length)
            throw new InvalidOperationException("Куча полная");

        heap[size] = value;
        size++;
        SiftUp(size - 1);
    }

    public int[] HeapSort()
    {
        int[] sortedArray = new int[size];
        int heapSize = size;

        for (int i = 0; i < heapSize; i++)
        {
            sortedArray[i] = ExtractMin();
        }

        return sortedArray;
    }

    private void Swap(int index1, int index2)
    {
        int temp = heap[index1];
        heap[index1] = heap[index2];
        heap[index2] = temp;
    }

    public override string ToString()
    {
        return string.Join(", ", heap[..size]);
    }
    public bool IsMinHeap()
    {
        for (int i = 0; i < size; i++)
        {
            int[] children = Children(i);

            if (children[0] != -1 && heap[i] < children[0])
                return false;

            if (children[1] != -1 && heap[i] < children[1])
                return false;
        }

        return true;
    }
}
