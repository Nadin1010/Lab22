using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab22
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);
            

            Func<Task<int[]>, int> func2 = new Func<Task<int[]>, int>(SumArray);
            Task<int> task2 = task1.ContinueWith(func2);

            Func<Task<int[]>, int> func3 = new Func<Task<int[]>, int>(MaxIndexArray);
            Task<int> task3 = task1.ContinueWith(func3);

            task1.Start();
            Console.ReadKey();
        }

        static int[] GetArray(object a)
        {
            int n = (int)a;
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 30);
            }
            return array;
        }

        static int SumArray(Task<int[]> task)
        {
            int[] array = task.Result;
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            Console.WriteLine(sum);

                return sum;
        }

            static int MaxIndexArray(Task<int[]> task)
            {
            int[] array = task.Result;
                int max = array[0];
            int MaxIndexArray = 0;
                for (int i = 0; i < array.Count(); i++)
                {
                    if (max < array[i])
                    {
                        max = array[i];
                        MaxIndexArray = i;
                       
                    }
                }

            Console.WriteLine(max);
            return max;
            }
        }
    } 
