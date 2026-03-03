using System;

namespace Huongdoituong_SinhVien
{
    public class Student
    {
        //neu private thi them set va get de lay ra
        private string id;
        private string name;
        private double gpa;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Gpa
        {
            get { return gpa; }
            set
            { 
                if(value >= 0 && value <= 10)
                {
                    gpa = value;
                }
                else
                {
                    Console.WriteLine("Diem Gpa khong hop le !");
                }
            }
        }

        public void Input()
        {
            Console.Write("Id: ");
            id = Console.ReadLine();
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Gpa: ");
            gpa = double.Parse(Console.ReadLine());
        }

        public void Infor()
        {
            Console.WriteLine("-----Thong tin Sinh Vien-----");
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Gpa: {gpa}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student sv1 = new Student();

            sv1.Input();
            sv1.Infor();
        }
    }
}
