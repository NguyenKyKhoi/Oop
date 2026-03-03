using System;
using System.Reflection.Metadata;

namespace _1_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // a) Nhap mang
            int[] arr = NhapMang();

            // b) Xuat mang vua nhap
            Console.Write("Mang vua nhap la: ");
            XuatMang(arr);

            // c) Phan tu lon nhat trong mang
            Console.WriteLine($"\nPhan tu lon nhat trong mang la: {TimMax(arr)}");

            // d) Kiem tra mang da duoc sap xep tang dan hay chua
            Console.WriteLine($"Mang {(KiemTraSapXepTang(arr) ? "da" : "chua")} duoc sap xep tang dan");

            // e) Sap xep mang theo thu tu tang dan
            Console.Write("Mang sau khi sap xep tang dan: ");
            XuatMang(SapXepMangTangv2(arr));

            // f) Tach mang chan va le
            TachMang(arr);
        }
        static int[] NhapMang()
        {
            int n = 0;

            do
            {
                Console.Write("Nhap so luong phan tu trong mang: ");
                if (!int.TryParse(Console.ReadLine(), out n)) ;
            }
            while (n <= 0);

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhap phan tu thu [{i}]: ");
                int.TryParse(Console.ReadLine(), out arr[i]);
            }

            return arr;
        }
        static void XuatMang(int[] arr)
        {
            if (arr.Length == 0)
                Console.WriteLine("Mang khong co phan tu nao");
            else
            {
                foreach (var item in arr)
                {
                    Console.Write(item + " ");
                }
            }
        }
        static int TimMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i <= arr.Length - 1; i++)
            {
                if (arr[i] > max) max = arr[i];
            }
            return max;
        }
        static bool KiemTraSapXepTang(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1]) return false;
            }
            return true;
        }
        static void SapXepMangTangv1(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
        static int[] SapXepMangTangv2(int[] arr)
        {
            int[] arrNew = (int[])arr.Clone();
            Array.Sort(arrNew);
            return arrNew;
        }
        static void TachMang(int[] arr)
        {
            int demChan = 0;
            int demLe = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                    demChan++;
                else
                    demLe++;
            }

            // Khai bao mang chan ve le
            int[] mangChan = new int[demChan];
            int[] mangLe = new int[demLe];

            demChan = 0;
            demLe = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                    mangChan[demChan++] = arr[i];
            }else
                mangLe[demLe++] = arr[i];
        }

        Console.Write("\nMang chan gom cac phan tu: ");
        XuatMang(mangChan);
        Console.Write("\nMang le gom cac phan tu: ");
        XuatMang(mangLe);
    }
}
