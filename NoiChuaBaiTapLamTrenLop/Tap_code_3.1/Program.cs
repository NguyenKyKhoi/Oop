using System.Security.Cryptography.X509Certificates;

namespace Tap_code_3._1
{

    public class Xe
    {
        private string bienXe;
        private int namSanXuat;
        private double gia;

        public string BienXe
        {
            get { return bienXe; }
            set
            {
                if (value.Length == 8)
                {
                    bienXe = value;
                }
                else
                {
                    Console.WriteLine("Dữ liệu biển số không đúng !!!");
                }
            }
        }

        public int NamSanXuat
        {
            get { return namSanXuat; }
            set
            {
                if(value > 0 && value <= 2026)
                {
                    namSanXuat = value;
                }
                else
                {
                    Console.WriteLine("Dữ liệu năm không đúng");
                }
            }
        }

        public double Gia
        {
            get { return gia; }
            set
            {
                if(value > 0)
                {
                    gia = value;
                }
            }
        }

        public Xe() { }
        public Xe(string bienXe, int namSanXuat, double gia)
        {
            this.bienXe = bienXe;
            this.namSanXuat = namSanXuat;
            this.gia = gia;
        }

        public virtual void Nhap()
        {
            Console.WriteLine("Nhập thông tin xe : ");
            Console.Write("Biển số xe : ");
            BienXe = Console.ReadLine();
            Console.Write("Năm sản xuất : ");
            if(int.TryParse(Console.ReadLine(), out int nam))
            {
                NamSanXuat = nam;
            }
            Console.Write("Giá xe : ");
            if(double.TryParse(Console.ReadLine(), out double gia))
            {
                Gia = gia;
            }
        }

        public virtual void Xuat()
        {
            Console.WriteLine("Thông tin xe : ");
            Console.Write("Biển số xe: ");
            Console.WriteLine(BienXe);
            Console.Write("Năm sản xuất: ");
            Console.WriteLine(namSanXuat);
            Console.Write("Giá xe : ");
            Console.WriteLine(Gia);
        }
    }

    public class XeCon : Xe
    {
        private int soChoNgoi;
        private string loaiXe;

        public int SoChoNgoi
        {
            get { return soChoNgoi; }
            set
            {
                if(value > 0 && value <= 8)
                {
                    soChoNgoi = value;
                }
            }
        }

        public string LoaiXe
        {
            get; set;
        }

        public XeCon() { }
        public XeCon(string bienSo, int namSanXuat, double gia, int soChoNgoi, string loaiXe) : base(bienSo, namSanXuat, gia)
        {
            this.SoChoNgoi = soChoNgoi;
            this.loaiXe = loaiXe;
        }


        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Số chỗ ngồi: ");
            if(int.TryParse(Console.ReadLine(), out int chongoi))
            {
                SoChoNgoi = chongoi;
            }

            Console.WriteLine("Loại xe (sedal/SUV/bán tải) : ");
            LoaiXe = Console.ReadLine();
            Console.WriteLine("===========================");
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.Write("Số chỗ ngồi: ");
            Console.WriteLine(SoChoNgoi);
            Console.Write("Loại xe: ");
            Console.WriteLine(LoaiXe);
            Console.WriteLine("===========================");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Nhập số lượng xe : ");
            int n = int.Parse(Console.ReadLine());

            XeCon[] dsXeCon = new XeCon[n];
            Console.WriteLine("Nhập danh sách xe con : ");
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"Xe con thứ {i + 1}");
                XeCon temp = new XeCon();
                temp.Nhap();
                dsXeCon[i] = temp;
            }

            Console.WriteLine("Danh sách xe con : ");
            for(int i = 0; i < n; i++)
            {
                dsXeCon[i].Xuat();
            }
            Console.WriteLine("----------------------------------");
            Console.Write("Số xe có giá cao nhât: ");
            double giacaonhat = 0;
            for(int i = 0;  i < n; i++)
            {
                if (dsXeCon[i].Gia > giacaonhat)
                {
                    giacaonhat = dsXeCon[i].Gia;
                }
            }
            Console.WriteLine(giacaonhat);
            Console.Write("Số xe có giá thấp nhất: ");
            double giathapnhat = 1e5;
            for(int i = 0; i < n; i++)
            {
                if(giathapnhat > dsXeCon[i].Gia)
                {
                    giathapnhat = dsXeCon[i].Gia;
                }
            }
            Console.WriteLine(giathapnhat);
            Console.WriteLine("Check xem danh sách các biển số trùng 2 số đầu");
            Console.Write("Nhập 2 chữ số đầu biến số: ");
            string sodau = Console.ReadLine();

            foreach(var xe in dsXeCon){
                Boolean check = true;
                for (int i = 0; i < sodau.Length; i++)
                {
                    if (xe.BienXe[i] != sodau[i])
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                    xe.Xuat();
            }
            Console.WriteLine("Danh sách sau khi được sắp xệp---------");
            for (int i = 0; i < n - 1; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    if (dsXeCon[i].NamSanXuat > dsXeCon[j].NamSanXuat)
                    {
                        XeCon temp = dsXeCon[i];
                        dsXeCon[i] = dsXeCon[j];
                        dsXeCon[j] = temp;
                    }
                }
            }

            foreach(var xe in dsXeCon)
            {
                xe.Xuat();
            }
        }
    }
}
