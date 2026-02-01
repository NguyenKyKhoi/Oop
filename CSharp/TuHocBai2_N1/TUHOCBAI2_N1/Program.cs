using System;
using System.Data;
using System.Text;

namespace TuHocBai2_N1
{
    class Program()
    {
        static void Main(string[] args)
        {
            //chuyển sang tiếng Việt
            Console.OutputEncoding = Encoding.UTF8;

            string hoTen;
            float diemToan ;
            float diemVan;

            Console.WriteLine("Ho va Ten : ");
            hoTen = Console.ReadLine();

            Console.WriteLine("Nhap diem toan : ");
            diemToan = float.Parse(Console.ReadLine());

            Console.WriteLine("Nhap diem Van : ");
            diemVan = float.Parse(Console.ReadLine());

            Console.WriteLine("Học Sinh tên {0} có điểm Toán là {1}, điểm Văn là {2}", hoTen, diemToan, diemVan);
            //Console.ReadKey();  

            //kiểu dữ liệu nội suy : var

            var y = 113;
            Console.WriteLine("Kieu du lieu cua y la {0}", y.GetType().ToString());
            Console.ReadKey();
        
        }
    }
}
