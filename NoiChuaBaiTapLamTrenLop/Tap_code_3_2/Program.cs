using System.Transactions;

namespace Tap_code_3_2
{
    public class NhanVien
    {
        private String hoTen;
        private DateTime ngaySinh;
        private double luong;

        public NhanVien(string hoTen, DateTime ngaySinh)
        {
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
        }

        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public double Luong { get => luong; set => luong = value; }

        public virtual void TinhLuong() { }

        public virtual void Xuat()
        {
            Console.WriteLine($"HỌ TÊN : {HoTen}, NGÀY SINH: {NgaySinh:MM/dd/yyyy}, Lương: {Luong} VNĐ");
        }
    }
    public class NhanVienVP : NhanVien
    {
        private int soNgayLamViec;

        public NhanVienVP(string hoTen, DateTime ngaySinh, int soNgayLamViec): base(hoTen, ngaySinh)
        {
            this.SoNgayLamViec = soNgayLamViec;
        }

        public int SoNgayLamViec { get => soNgayLamViec; set => soNgayLamViec = value; }

        public override void TinhLuong()
        {
            Luong = SoNgayLamViec * 1000000;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($" ,SỐ NGÀY LÀM VIỆC: {SoNgayLamViec}");
        }
    }

    public class NhanVienSX : NhanVien
    {
        private int soSanPham;

        public int SoSanPham { get => soSanPham; set => soSanPham = value; }

        public NhanVienSX(string hoTen, DateTime ngaySinh, int soSanPham):base(hoTen, ngaySinh){
            this.soSanPham = soSanPham;
        }

        public override void TinhLuong()
        {
            Luong = SoSanPham * 5000;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($" ,SỐ SẢN PHẨM: {SoSanPham}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            List<NhanVien> dsNhanVien = new List<NhanVien>();
            

            Console.Write("Nhập số lượng nhân viên: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhân viên thứ {i + 1}");
                Console.Write("HỌ TÊN : ");
                string hoten = Console.ReadLine();
                Console.Write("NGÀY SINH : ");
                DateTime ngaysinh = DateTime.Parse(Console.ReadLine());
                Console.Write("LOẠI NHÂN VIÊN: 0 - NHAN VIEN VAN PHONG, 1 - NHAN VIEN SAN XUAT");
                int loainhanvien = int.Parse(Console.ReadLine());

                if (loainhanvien == 0)
                {
                    Console.Write("SỐ NGÀY LÀM VIỆC: ");
                    int songaylamviec = int.Parse(Console.ReadLine());
                    NhanVienVP temp = new NhanVienVP(hoten, ngaysinh, songaylamviec);
                    temp.TinhLuong();
                    dsNhanVien.Add(temp);

                }
                else if (loainhanvien == 1)
                {
                    Console.Write("SỐ SẢN PHẨM: ");
                    int sosanpham = int.Parse(Console.ReadLine());
                    NhanVienSX temp = new NhanVienSX(hoten, ngaysinh, sosanpham);
                    temp.TinhLuong();
                    dsNhanVien.Add(temp);
                }
                else
                {
                    Console.WriteLine("Loại nhân viên không hợp lệ");
                    i--;
                }
            }

            for(int i = 0; i < n - 1; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    if (dsNhanVien[i].Luong < dsNhanVien[j].Luong)
                    {
                        NhanVien temp = dsNhanVien[i];
                        dsNhanVien[i] = dsNhanVien[j];
                        dsNhanVien[j] = temp;
                    }
                }
            }

            foreach(var nv in dsNhanVien){
                nv.Xuat();
            }

        }
    }
}
