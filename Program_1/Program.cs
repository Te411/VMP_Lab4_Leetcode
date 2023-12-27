//Создайте консольное приложение в рамках которого будет выполняться следующее задачка с leetcode.
//-Покройте все методы тестами
//-Создайте тестовые методы, которые будут принимать тестовые значения из примеров,
//и сравнивать полученные результаты с обозначенными выходными решениями.
//-Обработайте исключения с помощью блоков try, catch, finally на данных, которые выходят за ограничения!
//Учитывая массив точек, где Points[i] = [xi, yi] представляет точку на плоскости XY и целое число k, верните k ближайших точек к началу координат (0, 0).
//Расстояние между двумя точками на плоскости XY — это евклидово расстояние (т. е. √(x1 — x2)2 + (y1 — y2)2).
//Вы можете вернуть ответ в любом порядке. Ответ гарантированно будет уникальным (за исключением порядка, в котором он находится).

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_Program1
{
    public class Point
    {
        private double x;
        private double y;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point(double _x, double _y)
        {
            x = _x;
            y = _y;
        }

        public double Distance => Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            int k = 999;
            int size = -1;
            Point[] point;

            Console.WriteLine("Введите количество точек: ");
            do
            {
                try
                {
                    size = Convert.ToInt32(Console.ReadLine());
                    while (size >= Math.Pow(10, 2))
                    {
                        Console.WriteLine("Некорректный ввод! Попробуйте еще раз!");
                        size = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректный ввод! Попробуйте еще раз!");
                    size = -1;
                }
            } while (size == -1);

            point = new Point[size];


            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Введите {i + 1} точку в формате \"x y\" ");
            input:
                string input = Console.ReadLine();
                string[] values = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int inegerX = 0;
                int inegerY = 0;

                try
                {
                    inegerX = Convert.ToInt32(values[0]);
                    inegerY = Convert.ToInt32(values[1]);
                    point[i] = new Point(inegerX, inegerY);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод точки! Введите еще раз.");
                    goto input;
                }
            }

            Console.Write("Введите число k: ");
            do
            {
                try
                {
                    k = Convert.ToInt32(Console.ReadLine());
                    while (k < 1 || k >= size)
                    {
                        Console.WriteLine("Некорректный ввод! Попробуйте еще раз!");
                        k = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректный ввод! Попробуйте еще раз!");
                    k = 999;
                }
            } while (k == 999);


            int[] selected = new int[point.Length];
            for (int i = 0; i < selected.Length; i++)
            {
                selected[i] = -1;
            }

            int index = 0;
            int exp = 0;
            for (int j = k; j != 0; j--)
            {
                int minIndex = 0;
                double min = 999999;
                for (int i = 0; i < point.Length; i++)
                {
                    if (selected[i] != -1)
                    {
                        continue;
                    }
                    else
                    {
                        if (point[i].Distance < min)
                        {
                            minIndex = i;
                            min = point[i].Distance;
                        }
                        selected[index] = minIndex;
                    }
                }
                Console.WriteLine($"({point[minIndex].X} {point[minIndex].Y})");




                //Point[] expected = new Point[point.Length];
                //expected[exp].X = point[minInd].X;
                //expected[exp].Y = point[minInd].Y;
            }

            Console.ReadLine();
        }
    }
}
