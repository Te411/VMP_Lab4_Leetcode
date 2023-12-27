//Учитывая строку s, представляющую допустимое выражение, 
//реализуйте базовый калькулятор для ее вычисления и возвращайте результат вычисления.
//Примечание. Вам не разрешено использовать какие-либо встроенные функции, 
//которые оценивают строки как математические выражения, например eval().

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_Program2
{
    internal class Program
    {
        class Stack
        {
            private int[] arr;
            private int top;
            private int maxSize;

            public Stack(int size)
            {
                maxSize = size;
                arr = new int[maxSize];
                top = 0;
            }

            public void Push(int number)
            {
                arr[top++] = number;
            }

            public int Pop()
            {

                return arr[--top];

            }

            public void clear()
            {
                top = 0;
            }
            public void size()
            {

                Console.WriteLine($"Количество '(': {top}");

            }
            public bool IsEmpty()
            {
                return (top == 0);
            }
        }


        static void Main(string[] args)
        {
            int x = 0;
            do
            {
                Console.Write("Введите текст (Не более 100 символов): ");
                string input = Console.ReadLine();
                Console.WriteLine();
                while (input.Length > 20)
                {
                    Console.WriteLine("Текст должен быть не более 100 символов!!!");
                    Console.Write("Введите еще раз: ");
                    input = Console.ReadLine();
                    Console.WriteLine();
                }

                Stack storeRes = new Stack(input.Length);
                Stack storeSign = new Stack(input.Length);
                int res = 0;
                int sign = 1;

                for (int i = 0; i < input.Length; i++)
                {
                    switch (input[i])
                    {
                        case '+':
                            sign = 1;
                            break;
                        case '-':
                            sign = -1;
                            break;
                        case '(':
                            storeRes.Push(res);
                            storeSign.Push(sign);
                            res = 0;
                            sign = 1;
                            break;
                        case ')':
                            if (storeSign.IsEmpty() || storeRes.IsEmpty())
                            {
                                break;
                            }
                            else
                            {
                                res *= storeSign.Pop();
                                res += storeRes.Pop();
                            }
                            break;
                        case ' ':
                            break;
                        default:
                            int value = -99;

                            if (i < input.Length - 1)
                            {
                                try
                                {

                                    value = Int32.Parse(input[i + 1].ToString());
                                }
                                catch (FormatException)
                                {
                                    value = -99;
                                }
                            }

                            if (value != -99)
                            {
                                string answer = input[i].ToString() + input[i + 1].ToString();
                                res += (Int32.Parse(answer)) * sign;
                                sign = 1;
                                i++;
                            }
                            else
                            {
                                res += Int32.Parse(input[i].ToString()) * sign;
                                sign = 1;
                            }
                            break;
                    }
                }
                Console.WriteLine(res);

                Console.WriteLine("Введите 1, чтобы продолжить либо 0, чтобы завершить работу.");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                while (x != 0 && x != 1)
                {
                    Console.WriteLine("Введите 1, чтобы продолжить либо 0, чтобы завершить работу.");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
            } while (x != 0);
        }
    }
}
