using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            char phepToan;
            double ketQua = 0;

            Console.WriteLine("Nhap a = ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap b = ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap phep toan (+,-,*,/): ");
            phepToan = char.Parse(Console.ReadLine());

            switch (phepToan)
            {
                case '+':
                    ketQua = a + b;
                    Console.WriteLine("\n{0} + {1} = {2}", a, b, ketQua);
                    break;
                case '-':
                    ketQua = a - b;
                    Console.WriteLine("\n{0} - {1} = {2}", a, b, ketQua);
                    break;
                case '*':
                    ketQua = a * b;
                    Console.WriteLine("\n{0} * {1} = {2}", a, b, ketQua);
                    break;
                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine("Khong chia duoc !");
                    }
                    else
                    {
                        ketQua = a / b;
                        Console.WriteLine("\n{0} / {1} = {2}", a, b, ketQua);
                    }
                    break;
                default:
                    Console.Write("khong co phep toan nao !");
                    break;
            }


        }
    }
}



