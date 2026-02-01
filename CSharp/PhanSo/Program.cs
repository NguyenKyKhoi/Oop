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
            set { _mauSo = value;}
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
    }

    class Program
    {
        static void Main()
        {
            
        }
    }
}