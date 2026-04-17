using System;

public class XeMay{

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

    public string BienSo { get => bienSo; set{ bienSo = value;} }
    public int NamSanXuat { get => namSanXuat; set => namSanXuat = value; }
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
        Console.Write("Biển số = ");
        BienSo = Console.ReadLine()!;
        Console.Write("Năm sản xuất : ");
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

    public double CongSuatDongCo { get => congSuatDongCo; set => congSuatDongCo = value; }

    public XeDien() : base()
    {
        CongSuatDongCo = 0;
    }

    public XeDien(string bienSo, int namSanXuat, double giaBan, double congSuatDongCo) : base(bienSo, namSanXuat, giaBan)
    {
        this.congSuatDongCo = congSuatDongCo;
    }

    public override void Nhap()
    {
        base.Nhap();

        Console.Write("Công suất động cơ : ");
        CongSuatDongCo = double.Parse(Console.ReadLine()!);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Công suất động cơ : {CongSuatDongCo}");
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
            Console.WriteLine($"Nhập thông tin xe thứ {i + 1}");
            XeDien temp = new XeDien();
            temp.Nhap();
            dsXeDien.Add(temp);
            Console.WriteLine("===================");
        }

        foreach(var t in dsXeDien)
        {
            t.Xuat();
        }

        for(int i = 0; i < n - 1; i++)
        {
            for(int j = i + 1; j < n; j++)
            {
                if(dsXeDien[i].ThoiHanSuDung() < dsXeDien[j].ThoiHanSuDung())
                {
                    XeDien tem = dsXeDien[i];
                    dsXeDien[i] = dsXeDien[j];
                    dsXeDien[j] = tem;
                }
            }
        }

        Console.WriteLine("DANH SÁCH XE ĐIỆN SAU KHI SẮP XẾP");
        foreach(var x in dsXeDien)
        {
            x.Xuat();
            Console.WriteLine("---------------");
        }

        Console.WriteLine("DANH SÁCH XE ĐIỆN HẾT THỜI HẠN SỬ DỤNG");
        Boolean flag = false;
        foreach(var temp in dsXeDien)
        {
            if(temp.ThoiHanSuDung() <= 0)
            {
                temp.Xuat();
                Console.WriteLine("---------------");
                flag = true;
            }
        }
        if(flag == false)
        {
            Console.WriteLine("KHÔNG CÓ XE NÀO HẾT THỜI HẠN");
        }

        Console.WriteLine("THÊM PHẦN TỬ MỚI : ");
        XeDien temmp = new XeDien();
        temmp.Nhap();
        dsXeDien.Add(temmp);

        Console.WriteLine("======DANH SÁCH SAU KHI THÊM====== ");
        foreach(var i in dsXeDien)
        {
            i.Xuat();
            Console.WriteLine("---------------");
        }

        Console.WriteLine("Phần tử cần xóa 1");
        dsXeDien.RemoveAt(1);
        Console.WriteLine("======DANH SÁCH SAU KHI XÓA======");
        foreach(var i in dsXeDien)
        {
            i.Xuat();
            Console.WriteLine("---------------");
        }


        Console.WriteLine("TIM KIẾM");
        string searchPlate = Console.ReadLine();
        XeDien ketQua = dsXeDien.Find(x => x.BienSo == searchPlate);

        if (ketQua != null) {
            Console.WriteLine("Đã tìm thấy xe:");
            ketQua.Xuat();
        } else {
            Console.WriteLine("Không tìm thấy xe nào!");
        }

        Console.WriteLine("SO SÁNH");
        if (dsXeDien[1].GiaBan > dsXeDien[2].GiaBan) {
            Console.WriteLine("Xe 1 đắt hơn xe 2");
        } else if (dsXeDien[1].GiaBan < dsXeDien[2].GiaBan) {
            Console.WriteLine("Xe 2 đắt hơn xe 1");
        } else {
            Console.WriteLine("Hai xe bằng giá nhau");
        }
    }
}
