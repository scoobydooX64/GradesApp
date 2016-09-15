using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void GiveBookName(GradeBook book)
        {
            book.Name = "The Gradebook";
        }

        static void IncrementNumber(out int num)
        {
            num = 10;
        }
        static void Main(string[] args)
        {
            //Arrays();
            //Immutable();
            //PassByValueAndRef();
            //WriteNames("Okanda","Niroda","Hashan");

            IGradeTracker book = CreateGradeBook();

            try
            {
                string[] lines = File.ReadAllLines("grades.txt");
                foreach (var line in lines)
                {
                    float grade = float.Parse(line);
                    book.AddGrade(grade);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found");
            }
        
            //try
            //{
            //    using (FileStream stream = File.Open("grades.txt", FileMode.Open))
            //    {
            //        using (StreamReader reader = new StreamReader(stream))
            //        {                      
            //            string line = reader.ReadLine();
            //            while (line != null)
            //            {
            //                float grade = float.Parse(line);
            //                book.AddGrade(grade);
            //                line = reader.ReadLine();
            //            }
            //        }
            //    }
            //}
            //catch (FileNotFoundException ex)
            //{
            //    Console.WriteLine("File not found");
            //}
            

            //book.AddGrade(90f);
            //book.AddGrade(30f);
            //book.AddGrade(60f);

            //try
            //{
            //    Console.Write("Please enter a name for the book : ");
            //    book.Name = Console.ReadLine();
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine("Invalid name");
            //}

            GradeStatistics stats = book.ComputeStatistics();

            //book.NameChanged = new NamedChangedDelegate(OnNameChanged);
            //book.NameChanged += OnNameChanged;          
            //book.Name = "Harsha";

            Console.WriteLine(book.Name);
            Console.WriteLine("Average Grade : " + stats.AverageGrade);
            Console.WriteLine("Lowest Grade : " + stats.LowestGrade);
            Console.WriteLine("HigestGrade : " + stats.HigestGrade);

            //WriteByteArray(stats.AverageGrade);

            Console.ReadLine();
        }

        private static IGradeTracker CreateGradeBook()
        {
            IGradeTracker book = new ThrowAwayGradeBook("Okanda");
            return book;
        }

        private static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Name chaned from {0} to {1}", args.OldValue,args.NewValue);
        }     

        private static void WriteNames(params string[] names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
        private static void WriteByteArray(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteBytes(bytes);
        }

        private static void WriteByteArray(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteBytes(bytes);
        }

        private static void WriteBytes(byte[] bytes)
        {
            foreach (byte b in bytes)
            {
                Console.WriteLine("0X{0:X}", b);
            }
        }

        private static void Arrays()
        {
            float[] grades = new float[3];

            AddGrades(grades);

            foreach (var grade in grades)
            {
                Console.WriteLine(grade);
            }
        }

        private static void AddGrades(float[] grades)
        {
            if (grades.Length >= 3)
            {
                grades[0] = 90f;
                grades[1] = 60f;
                grades[2] = 30f;
            }
        }

        

        private static void Immutable()
        {
            string name = " Harsha ";
            name=name.Trim();
            Console.WriteLine(name);

            DateTime date = new DateTime(2015, 7, 2);
            date=date.AddDays(3);
            Console.WriteLine(date);
        }

        private static void PassByValueAndRef()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            GiveBookName(g1);
            Console.WriteLine(g2.Name);

            int x = 4;
            IncrementNumber(out x);
            Console.WriteLine(x);
        }
    }
}
