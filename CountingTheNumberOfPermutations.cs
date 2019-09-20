using System;
using System.Collections.Generic;
using System.Numerics;

namespace Test
{
    class MainClass
    {
        static List<List<BigInteger>> array = new List<List<BigInteger>>();

        public static void Main(string[] args)
        {
            var input = (n: 0, k: 0);
            do
            {
                Console.WriteLine("input n");
                input.n = Input();
                Console.WriteLine("input k");
                input.k = Input();

                if (input.n < 0 || input.k < 0)
                    break;

                if (array.Count < input.n)
                    Calculate(level: input.n);

                Console.WriteLine($"C({input.n},{input.k}) = {array[input.k][input.n - input.k]}");
                Console.WriteLine("_________________");

            } while (true);
        }

        public static int Input()
        {
            var input = Console.ReadLine();

            if (input == "print")
            {
                PrintArray();
                return Input();
            }

            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        public static void PrintArray()
        {
            for (int i = 0; i < array.Count; i++)
            {
                for (int y = 0; y <= i; y++)
                {
                    Console.Write(array[y][i - y] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void Calculate(int level)
        {
            for (int i = array.Count; i <= level; i++)
            {
                for (int y = 0; y <= i; y++)
                {
                    if (y == i)
                    {
                        var collection = new List<BigInteger>
                        {
                            1
                        };
                        array.Add(collection);
                        continue;
                    }

                    if (y == 0)
                    {
                        array[0].Add(1);
                        continue;
                    }

                    array[y].Add(array[y - 1][i - y] + array[y][i - 1 - y]);
                }
            }
        }
    }
}
