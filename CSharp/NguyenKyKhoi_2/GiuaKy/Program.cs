using System;

public class XeMay
{
    private string bienSo;
    private int namSanXuat;
    private double giaBan;

    public XeMay(){}

    public XeMay(string bienSo, int namSanXuat, double giaBan)
    {
        this.bienSo = bienSo;
        this.namSanXuat = namSanXuat;
        this.giaBan = giaBan;
    }

    public string BienSo { get => bienSo; set => bienSo = value; }
    public int NamSanXuat { get => namSanXuat; 
    set
        {
            if(value > 0)
            {
                namSanXuat = value;
            }
        }
    }
    public double GiaBan { get => giaBan; 
    set
        {
            if(value > 0)
            {
                giaBan = value;
            }
        }
    }
    public virtual void Nhap()
    {
        Console.Write("Biển Số : ");
        BienSo = Console.ReadLine()!;
        Console.Write("Năm Sản Xuất : ");
        NamSanXuat = int.Parse(Console.ReadLine()!);
        Console.Write("Giá Bán : ");
        GiaBan = double.Parse(Console.ReadLine()!);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Biển Số : {BienSo}");
        Console.WriteLine($"Năm Sản Xuất : {NamSanXuat}");
        Console.WriteLine($"Giá Bán : {GiaBan}");
    }

    public virtual double ThoiHanSuDung()
    {
        return 0;
    }
}

public class XeDien : XeMay
{
    private double congSuatDongCo;
    const int THOIHAN = 10;

    public XeDien(){}

    public XeDien(string bienSo, int namSanXuat, double giaBan, double congSuatDongCo) : base(bienSo, namSanXuat, giaBan)
    {
        this.congSuatDongCo = congSuatDongCo;
    }

    public double CongSuatDongCo { get => congSuatDongCo; set => congSuatDongCo = value; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Cống Suất Động Cơ (Watt): ");
        CongSuatDongCo = double.Parse(Console.ReadLine()!);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Công Suất Động Cơ (Watt): {CongSuatDongCo}");
    }

    public override double ThoiHanSuDung()
    {
        base.ThoiHanSuDung();
        int namHienTai = DateTime.Now.Year;
        return THOIHAN - (namHienTai - NamSanXuat);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Nhập số lượng xe trong danh sách : ");
        int n = int.Parse(Console.ReadLine()!);
        List<XeDien> dsXeDien = new List<XeDien>(n);

        for(int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin xe thứ {i+1}");
            XeDien temp = new XeDien();
            temp.Nhap();
            dsXeDien.Add(temp);
            Console.WriteLine("===================");
        }

        Console.WriteLine("=====DANH SÁCH XE=====");
        foreach(var i in dsXeDien)
        {
            i.Xuat();
        }

        for(int i = 0; i < n - 1; i++)
        {
            for(int j = i; j < n; j++)
            {
                if(dsXeDien[i].ThoiHanSuDung() < dsXeDien[j].ThoiHanSuDung())
                {
                    XeDien y = dsXeDien[i];
                    dsXeDien[i] = dsXeDien[j];
                    dsXeDien[j] = y;
                }
            }
        }

        Console.WriteLine("=====DANH SÁCH XE ĐIỆN SAU KHI SẮP XẾP GIẢM DẦN=====");
        foreach(var i in dsXeDien)
        {
            i.Xuat();
        }

        int flag = 0;
        foreach(var tem in dsXeDien)
        {
            if(tem.ThoiHanSuDung() <= 0)
            {
                tem.Xuat();
                flag = 1;
            }
        }
        if(flag == 0)
        {
            Console.WriteLine("Không có xe nào hết thời hạn sử dụng");
        }

        Console.WriteLine("=====THÊM ĐỐI TƯỢNG MỚI=====");
        Console.Write("Biển Số : ");
        string bienso = Console.ReadLine()!;
        Console.Write("Năm Sản Xuất : ");
        int namsanxuat = int.Parse(Console.ReadLine()!);
        Console.Write("Giá Bán : ");
        double giaban = double.Parse(Console.ReadLine()!);
        Console.Write("Cống Suất Động Cơ : ");
        double congsuatdongco = double.Parse(Console.ReadLine()!);
        XeDien x = new XeDien(bienso, namsanxuat, giaban, congsuatdongco);
        dsXeDien.Add(x);

        Console.WriteLine("=====XÓA MỘT ĐỐI TƯỢNG=====");
        dsXeDien.RemoveAt(1);

        Console.WriteLine("=====DANH SÁCH SAU KHI XÓA=====");
        foreach(var i in dsXeDien)
        {
            i.Xuat();
        }

        Console.WriteLine("=====TÌM KIẾM=====");
        string search = Console.ReadLine()!;
        XeDien KetQua = dsXeDien.Find(x => x.BienSo == search);
        if(KetQua != null)
        {
            Console.WriteLine("Đã Tìm Thấy");
            KetQua.Xuat();
        }
        else
        {
            Console.WriteLine("Không tìm thấy");
        }

        if(dsXeDien[0].GiaBan < dsXeDien[1].GiaBan)
        {
            Console.WriteLine($"Xe có biển số {dsXeDien[1].BienSo} giá cao hơn");
        }
        else
        {
            Console.WriteLine($"Xe {dsXeDien[0].BienSo} giá cao hơn");
        }

        //tìm mức giá cao nhất, sửa tìm biển số đúng và cập nhật lại giá, 
        //xóa xe trong ds sau khi biết biển số
        
        Console.WriteLine("====================HỌC THÊM==========================");
        double max = 0;
        foreach(var t in dsXeDien)
        {
            if(t.GiaBan > max)
                max = t.GiaBan;
        }
        Console.WriteLine($"Mức giá cao nhất trong ds : {max}");

        Console.WriteLine("====================TÌM VÀ SỬA GIÁ==========================");
        Console.Write("Biển Số cần tìm : ");
        string searchs = Console.ReadLine();
        foreach(var e in dsXeDien)
        {
            if(e.BienSo == searchs)
            {
                Console.WriteLine("Đã Tìm Thấy");
                e.GiaBan = 200;
                Console.WriteLine("Giá Sau Khi Cập Nhật");
                e.Xuat();
            }
        }

        Console.WriteLine("====================XÓA XE SAU KHI TÌM THẤY==========================");
        Console.Write("Biển Số cần tìm xóa : ");
        string searchss = Console.ReadLine();
        int soluong = dsXeDien.RemoveAll(x => x.BienSo == searchss);
        if(soluong > 0)
        {
            Console.WriteLine("Đã Xóa");
        }
        else
        {
            Console.WriteLine("Không có phần tử cần xóa");
        }
        Console.WriteLine("======DANH SÁCH SAU KHI XÓA======");
        foreach(var o in dsXeDien)
        {
            o.Xuat();
        }
    }
}
