//Задание 1
//    string inputFilePath = "input.txt";
//    int[] heapArray = ReadHeapArrayFromFile(inputFilePath);

//    MinHeap heap = new MinHeap(heapArray.Length);
//    heap.BuildHeap(heapArray);

//    bool isMaxHeap = IsMaxHeap(heapArray.Length, heap);
//    string result = isMaxHeap ? "YES" : "NO";
//    Console.WriteLine(result);

//static int[] ReadHeapArrayFromFile(string filePath)
//{
//    string[] lines = File.ReadAllLines(filePath);
//    int[] heapArray = Array.ConvertAll(lines[1].Split(' '), int.Parse);
//    return heapArray;
//}

//static bool IsMaxHeap(int size, MinHeap heap)
//{
//    for (int i = 0; i < size; i++)
//    {
//        int[] children = heap.Children(i);
//        int leftChild = children[0];
//        int rightChild = children[1];

//        if (leftChild != -1 && heap.heap[i] < leftChild)
//            return false;

//        if (rightChild != -1 && heap.heap[i] < rightChild)
//            return false;
//    }

//    return true;
//}
//Задание 2
//string inputFilePath = "input.txt";
//int[] array = ReadArrayFromFile(inputFilePath);

//MinHeap heap = new MinHeap(array.Length);
//heap.BuildHeap(array);

//Console.WriteLine("Heap: " + heap.ToString());

//    static int[] ReadArrayFromFile(string filePath)
//{
//    string[] lines = File.ReadAllLines(filePath);
//    int size = int.Parse(lines[0]);
//    int[] array = Array.ConvertAll(lines[1].Split(' '), int.Parse);
//    return array;
//}
//Задание 3
string inputFilePath = "input.txt";
int[] array = ReadArrayFromFile(inputFilePath);

MinHeap heap = new MinHeap(array.Length);
heap.BuildHeap(array);

int[] sortedArray = heap.HeapSort();
Console.WriteLine("Sorted Array: " + string.Join(" ", sortedArray));

    static int[] ReadArrayFromFile(string filePath)
{
    string[] lines = File.ReadAllLines(filePath);
    int size = int.Parse(lines[0]);
    int[] array = Array.ConvertAll(lines[1].Split(' '), int.Parse);
    return array;
}