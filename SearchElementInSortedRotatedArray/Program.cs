using System;
using System.Linq;

namespace SearchElementInSortedRotatedArray
{
    class Program
    {
        public int binarySearch(int[] arr, int value, int low, int high)
        {
            if (low > high)
                return -1;

            int mid = (low + high) / 2;

            if (arr[mid] == value)
                return mid;

            if (value > arr[mid])
                return binarySearch(arr, value, mid + 1, high);
            else
                return binarySearch(arr, value, low, mid);
        }

        public int[] splitArray(int[] arr, int pivot, string str)
        {
            int[] tempArray1 = new int[pivot + 1];
            int[] tempArray2 = new int[arr.Length - (pivot + 1)];

            if (str == "leftArray")
            {
                for (int i = 0; i < pivot + 1; i++)
                    tempArray1[i] = arr[i];

                return tempArray1;
            }
            else
            {
                for (int i = 0; i < arr.Length - (pivot + 1); i++)
                {
                    tempArray2[i] = arr[pivot + 1 + i];
                }

                return tempArray2;
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            int[] arr = { 1, 2, 3, 4, 5 };
            int value = 4;
            int maxValue = arr.Max();
            int pivot = arr.ToList().IndexOf(maxValue);

            int indexOfValue;

            if (arr[pivot] == value)
                Console.WriteLine("Element found at index "+ pivot);
            else if (arr[0] > value)
            {
                int[] array = program.splitArray(arr, pivot, "rightArray");
                indexOfValue = program.binarySearch(array, value, 0, array.Length - 1);
                int len = indexOfValue + pivot + 1;
                Console.WriteLine("Element found at index " + len);
            }
            else
            {
                int[] array = program.splitArray(arr, pivot, "leftArray");
                indexOfValue = program.binarySearch(array, value, 0, array.Length - 1);
                Console.WriteLine("Element found at index " + indexOfValue);
            }
        }
    }
}
