using System;

namespace Bai_Tap_Mix
{
    class Program
    {
        public const int MAX = 100;

        //Nhap mang n so nguyen
        static void Input(int n, int[] arr)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("arr{0} : ", i);
                arr[i] = int.Parse(Console.ReadLine());
            }
        }

        //In cac phan tu ra mang hinh
        static void Output(int n, int[] arr)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
        }

        //Tra ve phan tu lon nhat cua mang
        static int LonNhat(int n, int[] arr)
        {
            int max = (int)-1e5;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        //Tra ve kieu boolean kiem tra mang da sap xep tang dan hay chua
        static bool CheckTangDan(int n, int[] arr)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i + 1] < arr[i])
                {
                    return false;
                }
            }
            return true;
        }

        //Mang sap xep theo thu tu tang dan
        static void SapXep(int n, int[] arr)
        {
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
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

        //Tach mang thanh 2 mang con 1 mang chua chan 1 mang chua le
        static void HaiMang(int n, int[] arr, int[] arr_chan, out int chan, int[] arr_le, out int le)
        {
            chan = 0;
            le = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    arr_chan[chan] = arr[i];
                    chan++;
                }
                else
                {
                    arr_le[le] = arr[i];
                    le++;
                }
            }
        }

        static void Main()
        {
            int n;
            int[] arr = new int[MAX];

            Console.Write("Nhap n : ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap mang : ");
            Input(n, arr);

            Console.Write("In mang : ");
            Output(n, arr);

            Console.Write("\nPhan tu lon nhat la : {0}", LonNhat(n, arr));

            if (CheckTangDan(n, arr) == true)
            {
                Console.Write("\nMang Tang Dan");
            }
            else
            {
                Console.Write("\nMang khong tang dan");
            }

            Console.Write("\nMang sau khi sap xep : ");
            SapXep(n, arr);
            Output(n, arr);

            int chan, le;
            int[] arr_chan = new int[MAX];
            int[] arr_le = new int[MAX];

            HaiMang(n, arr, arr_chan, out chan, arr_le, out le);
            Console.Write("\nMang phan tu Chan : ");
            Output(chan, arr_chan);
            Console.Write("\nMang phan tu Le : ");
            Output(le, arr_le);
        }
    }
}
