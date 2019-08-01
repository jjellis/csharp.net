using System;

namespace binary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public static int binary_search(int[] data, int item)
        {
            int min = 0;
            int N = data.Length;
            int max = N - 1;
            int mid;
           /* int mid = (min + max) / 2;
            while (min<= max)
            {
                if (data[mid] < item)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
                if{
                    (data[mid]==)
                }
            }
        }*/
        do
            {
                int mid = (min + max) / 2;
                if (data[mid] < item)
                {
                    min = mid + 1;

                }
                else
                {
                    max = mid - 1;
                }
                if (data[min == item])
                
                    return mid;
                
                while (mid){

            }
            }
    }
}
