namespace Codelai_3_3
{

    public class HinhVe
    {
        private double dienTich;

        public double DienTich { get => dienTich; set => dienTich = value; }

        public virtual void TinhDienTich()
        {

        }
    }

    public class HinhChuNhat : HinhVe
    {

        private double chieuDai;
        private double chieuRong;

        public HinhChuNhat(double chieuDai, double chieuRong)
        {
            this.chieuDai = chieuDai;
            this.chieuRong = chieuRong;
        }

        public double ChieuDai { get => chieuDai; set => chieuDai = value; }
        public double ChieuRong { get => chieuRong; set => chieuRong = value; }
        public override void TinhDienTich()
        {
            DienTich = ChieuDai * ChieuRong;
        }
    }

    public class HinhTron : HinhVe
    {
        private double banKinh;

        public HinhTron(double banKinh)
        {
            this.BanKinh = banKinh;
        }

        public double BanKinh { get => banKinh; set => banKinh = value; }

        public override void TinhDienTich()
        {
            DienTich = 3.14 * (BanKinh * BanKinh);
        }
    }

    public class HinhVuong : HinhChuNhat
    {
        private double canh;

        public HinhVuong(double canh) :base(canh, canh)
        {
            this.canh = canh;
        }

        public double Canh { get => canh; set => canh = value; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
