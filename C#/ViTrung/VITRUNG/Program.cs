using System;

namespace viTrung
{
    class Program
    {
        static void Main(String [] args)
        {
            int vt;
            double time;
            double ketQua;
            Console.Write("So Luong Vi Trung Ban Dau : ");
            vt = int.Parse(Console.ReadLine());
            Console.Write("Khoang thoi gian : ");
            time = double.Parse(Console.ReadLine());
            
            ketQua = vt * Math.Pow(2, time);

            Console.WriteLine("So Luong Vi Trung Sau {0}h La : {1}", time, ketQua);

        }
    }
}