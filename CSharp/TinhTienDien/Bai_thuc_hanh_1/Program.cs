using System;

namespace TinhTienDien
{
    class Program
    {
        const int Muc1 = 100, Muc2 = 150, Muc3 = 300;
        const int Gia1 = 2000, Gia2 = 2500, Gia3 = 3000;

        static void Main()
        {
            int sokWh = 0;
            double sotien = 0;

            Console.WriteLine("Nhap so kWh tieu thu (MOI) : ");
            sokWh = int.Parse(Console.ReadLine());

            if(sokWh <= Muc1){
                sotien = sokWh * Gia1; 
            }else if(sokWh <= Muc2){
                sotien = (Muc1 * Gia1) + ((sokWh - Muc1) * Gia2);
            }else if(sokWh <= Muc3){
                sotien = (Muc1 * Gia1) + ((Muc2 - Muc1) * Gia2) + ((sokWh - Muc2) * Gia3);
            }
            
            if(sokWh > Muc3)
            {
                sotien += sotien * 1.1;
            }

            Console.WriteLine("So tien : {0}", sotien);
        }
    }
}