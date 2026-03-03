namespace ViTrung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int vt;
            double time;
            double ketQua;
            Console.WriteLine("So vi trung ban dau : ");
            vt = int.Parse(Console.ReadLine());
            Console.WriteLine("Khoang thoi gian : ");
            time = double.Parse(Console.ReadLine());

            ketQua = vt * Math.Pow(2, time);

            Console.WriteLine("So Luong Vi Trung Sau {0}h La : {1}", time, ketQua);
        }
    }
}
