using System;

namespace Bai2_1
{
    public class PhanSo
    {
        private int _tuSo;
        private int _mauSo;

        public int TuSo
        {
            get { return _tuSo;}
            set { _tuSo = value;}
        }

        public int MauSo
        {
            get {return _mauSo;}
            set {_mauSo = value;}
        }

        public PhanSo(int ts, int ms)
        {
            _tuSo = ts;
            _mauSo = ms;
        }

        public PhanSo(PhanSo p)
        {
            _tuSo = p._tuSo;
            _mauSo = p._mauSo;
        }

        public void Input()
        {
            Console.WriteLine("Nhap tu so : ");
            _tuSo = int.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine("Nhap mau so: ");
                _mauSo = int.Parse(Console.ReadLine());
                if(_mauSo == 0)
                {
                    Console.WriteLine("Vui long nhap lai !");
                }
            }while(!(_mauSo != 0));
        }

        public void Output()
        {
            if(_mauSo == 0 || _mauSo == 1)
            {
                Console.WriteLine($"{_tuSo}");
            }
            else
            {
                Console.WriteLine($"{_tuSo}/{_mauSo}");
            }
        }

        private int TimUCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while(b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }

        public void Toigian()
        {
            int uscln = TimUCLN(_tuSo, _mauSo);
            _tuSo = _tuSo / uscln;
            _mauSo = _mauSo / uscln;

            if(_mauSo < 0)
            {
                _tuSo = -_tuSo;
                _mauSo = -_mauSo;
            }
        }

        public PhanSo Cong(PhanSo p)
        {
            int tuMoi = (this._tuSo * p._mauSo) + (this._mauSo * p._tuSo);
            int mauMoi = this._mauSo * p._mauSo;

            PhanSo KetQua = new PhanSo(tuMoi, mauMoi);
            KetQua.Toigian();
            return KetQua;
        }

        public PhanSo Tru(PhanSo p)
        {
            int tuMoi = (this._tuSo * p._mauSo) - (this._mauSo * p._tuSo);
            int mauMoi = this._mauSo * p._mauSo;

            PhanSo KetQua = new PhanSo(tuMoi, mauMoi);
            KetQua.Toigian();
            return KetQua;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            PhanSo ps1 = new PhanSo(0,1);
            PhanSo ps2 = new PhanSo(0,1);

            Console.WriteLine("Nhap thong tin: ");
            Console.WriteLine("Nhap thong tin phan so 1: ");
            ps1.Input();
            Console.WriteLine("Nhap thong tin phan so 2: ");
            ps2.Input();

            Console.WriteLine("\n---Phan so vua nhap---");
            Console.WriteLine("Phan so 1:"); ps1.Output(); Console.WriteLine();
            Console.WriteLine("Phan so 2:"); ps2.Output(); Console.WriteLine();

            Console.WriteLine("\n---Ket Qua---");
            ps1.Toigian();
            ps2.Toigian();
            Console.WriteLine("Phan so 1 sau khi toi gian"); ps1.Output(); Console.WriteLine();
            Console.WriteLine("Phan so 2 sau khi toi gian"); ps2.Output(); Console.WriteLine();

            Console.WriteLine("\n---Tinh Toan---");
            //tinh tong
            PhanSo tong = ps1.Cong(ps2);
            Console.WriteLine("Tong hai phan so");
            tong.Output();
            Console.WriteLine();

            //tinh hieu
            PhanSo hieu = ps1.Tru(ps2);
            Console.WriteLine("Hieu hai phan so");
            hieu.Output();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}