using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Demau_giuky
{
    public class XeMay
    {
        private String bienSo;
        private int namSanXuat;
        private double giaBan;

        public String BienSo
        {
            get { return bienSo; } set
            {
                if (value != null && value.Length == 8)
                {
                    bienSo = value;
                }
                else { Console.WriteLine("Nhập biển số sai !!!"); }

            }
        }
        
        public int NamSanXuat
        {
            get { return namSanXuat; }
            set
            {
                if (value <= 2026 && value >= 1)
                {
                    namSanXuat = value;
                }
                else
                {
                    Console.WriteLine("Nhập sai năm sản xuất !!!");
                }
            }
        }

        public double GiaBan
        {
            get { return giaBan; }
            set
            {
                if(value >= 0)
                {
                    giaBan = value;
                }
                else { Console.WriteLine("Giá trị không xác định !!!"); }
            }
        }

        public XeMay() { }
        public XeMay(string bienSo, int namSanXuat, double giaBan)
        {
            this.bienSo = bienSo;
            this.namSanXuat = namSanXuat;
            this.giaBan = giaBan;
        }

        public void Nhap()
        {
            Console.WriteLine("--- Nhập thông tin xe máy ---");
            Console.Write("Nhập biển số (8 ký tự): ");
            BienSo = Console.ReadLine();

            Console.Write("Năm sản xuất: ");
            if(int.TryParse(Console.ReadLine(), out int nam))
            {
                NamSanXuat = nam;
            }

            Console.Write("Giá bán: ");
            if(double.TryParse(Console.ReadLine(), out double gia))
            {
                GiaBan = gia;
            }
        }
        public void Xuat()
        {
            Console.WriteLine("--- Thông Tin Xe ---");
            Console.WriteLine($"Biển số: {BienSo}");
            Console.WriteLine($"Năm Sản Xuất: {NamSanXuat}");
            Console.WriteLine($"Giá bán: {GiaBan}");
            Console.WriteLine("--------------------------");
        }

        public virtual int ThoiHanSuDung()
        {
            int namHienTai = 2026;
            int tuoiXe = namHienTai - namSanXuat;
            int hanDinhMuc = 20;

            int conlai = hanDinhMuc - tuoiXe;

            return conlai > 0 ? conlai : 0;
        }
    }

    public class XeDien : XeMay
    {
        private double congSuatDongCo;
        private const int ThoiHan = 10;

        public double CongSuatDongCo
        {
            get { return congSuatDongCo; }
            set
            {
                if (value > 0) congSuatDongCo = value;
            }
        }

        public XeDien() : base() { }

        public XeDien(String bienSo, int namSanXuat, double giaBan, double congSuatDongCo) : base(bienSo, namSanXuat, giaBan)
        {
            this.congSuatDongCo = congSuatDongCo;
        }

        public new void Nhap()
        {
            base.Nhap();

            Console.WriteLine("Nhập công suất động cơ: ");
            if(double.TryParse(Console.ReadLine(), out double watt))
            {
                CongSuatDongCo = watt;
            }
        }

        public new void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Công suất động cơ: {CongSuatDongCo} Watt");
        }

        public override int ThoiHanSuDung()
        {
            int namHienTai = 2026;
            int conlai = ThoiHan - (namHienTai - NamSanXuat);

            return conlai > 0 ? conlai : 0;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // 1. Nhập danh sách xe điện
            List<XeDien> dsXeDien = new List<XeDien>();
            Console.Write("Nhập số lượng xe điện: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhập xe thứ {i + 1}:");
                XeDien xd = new XeDien();
                xd.Nhap();
                dsXeDien.Add(xd);
            }

            // 2. SẮP XẾP GIẢM DẦN THEO THỜI HẠN (Cách đơn giản cho người mới)
            // Chúng ta dùng 2 vòng lặp để so sánh từng cặp xe với nhau
            for (int i = 0; i < dsXeDien.Count - 1; i++)
            {
                for (int j = i + 1; j < dsXeDien.Count; j++)
                {
                    // Nếu xe đứng trước (i) có thời hạn NHỎ HƠN xe đứng sau (j)
                    // thì ta tráo đổi vị trí của chúng để đưa xe thời hạn lớn lên đầu
                    if (dsXeDien[i].ThoiHanSuDung() < dsXeDien[j].ThoiHanSuDung())
                    {
                        // Thuật toán tráo đổi (Swap) dùng biến tạm 'temp'
                        XeDien temp = dsXeDien[i];
                        dsXeDien[i] = dsXeDien[j];
                        dsXeDien[j] = temp;
                    }
                }
            }

            // 3. In danh sách sau khi đã sắp xếp
            Console.WriteLine("\n======= DANH SÁCH SAU KHI SẮP XẾP (GIẢM DẦN) =======");
            foreach (var xe in dsXeDien)
            {
                // In ra thông tin và thời hạn để kiểm tra
                Console.WriteLine($"Biển số: {xe.BienSo} | Thời hạn: {xe.ThoiHanSuDung()} năm");
            }

            // 4. Liệt kê các xe đã hết hạn (Thời hạn = 0)
            Console.WriteLine("\n======= CÁC XE ĐÃ HẾT THỜI HẠN =======");
            bool coXeHetHan = false;
            foreach (var xe in dsXeDien)
            {
                if (xe.ThoiHanSuDung() == 0)
                {
                    xe.Xuat();
                    coXeHetHan = true;
                }
            }
            if (!coXeHetHan) Console.WriteLine("Không có xe nào hết hạn.");

            Console.ReadLine();
        }
    }
}
