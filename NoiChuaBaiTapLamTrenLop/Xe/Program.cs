using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Xe
{
    private string _bienSo;
    private int _namSX;
    private double _gia;

    public string bienSo
    {
        get { return _bienSo; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                _bienSo = "Chưa có";
            else
                _bienSo = value;
        }
    }

    public int namSX
    {
        get { return _namSX; }
        set
        {
            if (value < 1900 || value > 2026)
                _namSX = 2024; // Gán mặc định nếu sai
            else
                _namSX = value;
        }
    }

    public double gia
    {
        get { return _gia; }
        set
        {
            // Giá xe không thể âm
            if (value < 0)
                _gia = 0;
            else
                _gia = value;
        }
    }

    public Xe()
    {
        bienSo = "";
        namSX = 0;
        gia = 0;
    }
    public Xe(string bienSo, int namSX, double gia)
    {
        this.bienSo = bienSo;
        this.namSX = namSX;
        this.gia = gia;
    }
    public virtual void Nhap()
    {
        Console.Write("Nhap bien so: ");
        bienSo = Console.ReadLine();
        Console.Write("Nhap nam san xuat: ");
        namSX = int.Parse(Console.ReadLine());
        Console.Write("Nhap gia (trieu dong): ");
        gia = double.Parse(Console.ReadLine());
    }
    public virtual void Xuat()
    {
        Console.WriteLine("Bien so xe: {0}, nam san xuat: {1}, gia: {2} (trieu dong)", bienSo, namSX, gia);
    }
}
class XeCon : Xe
{
    public int soCN { get; set; }
    public string loaiXe { get; set; }

    public XeCon()
    {
        soCN = 0;
        loaiXe = "";
    }
    public XeCon(string bienSo, int namSX, double gia, int soCN, string loaiXe) : base(bienSo, namSX, gia)
    {
        this.soCN = soCN;
        this.loaiXe = loaiXe;
    }
    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap so cho ngoi: ");
        soCN = int.Parse(Console.ReadLine());
        Console.Write("Nhap loai xe: ");
        loaiXe = Console.ReadLine();
    }
    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine("So cho ngoi: {0}, Loai xe: {1}", soCN, loaiXe);
    }
}
class Program
{
    static void Main(string[] args)
    {
        int n;
        Console.Write("Nhap so luong xe: ");
        n = int.Parse(Console.ReadLine());

        XeCon[] danhSachXe = new XeCon[n];

        for (int i = 0; i < n; i++)
        {
            XeCon xe = new XeCon();
            Console.WriteLine("Nhap thong so cua xe thu {0}:", i);
            xe.Nhap();
            danhSachXe[i] = xe;
        }

        Console.WriteLine("\nDanh sach xe va thong so cua xe");
        for (int i = 0; i < n; i++)
        {
            danhSachXe[i].Xuat();
        }

        XeCon xeGiaThapNhat = danhSachXe[0];
        double giaThapNhat = danhSachXe[0].gia;
        for (int i = 1; i < n; i++)
        {
            if (danhSachXe[i].gia < giaThapNhat)
            {
                giaThapNhat = danhSachXe[i].gia;
                xeGiaThapNhat = danhSachXe[i];
            }
        }
        Console.Write("\nXe gia thap nhat: ");
        xeGiaThapNhat.Xuat();

        XeCon xeGiaCaoNhat = danhSachXe[0];
        double giaCaoNhat = danhSachXe[0].gia;
        for (int i = 1; i < n; i++)
        {
            if (danhSachXe[i].gia > giaCaoNhat)
            {
                giaCaoNhat = danhSachXe[i].gia;
                xeGiaCaoNhat = danhSachXe[i];
            }
        }
        Console.Write("\nXe gia cao nhat: ");
        xeGiaCaoNhat.Xuat();

        string temp;
        Console.Write("\nNhap 2 chu so dau cua bien so: ");
        temp = Console.ReadLine();
        Console.WriteLine("Tat ca xe thuoc tinh co bien so {0}: ", temp);
        foreach (var xe in danhSachXe)
        {
            bool check = true;
            for (int j = 0; j < temp.Length; j++)
            {
                if (xe.bienSo[j] != temp[j])
                {
                    check = false;
                    break;
                }
            }
            if (check)
                xe.Xuat();
        }

        Console.WriteLine("\nDanh sach xe sau khi sap xep theo nam san xuat: ");
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (danhSachXe[i].namSX > danhSachXe[j].namSX)
                {
                    XeCon tempDS = danhSachXe[i];
                    danhSachXe[i] = danhSachXe[j];
                    danhSachXe[j] = tempDS;
                }
            }
        }
        foreach (var xe in danhSachXe)
        {
            xe.Xuat();
        }
    }
}