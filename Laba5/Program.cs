using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laba5
{
    class Program
    {
        static Student[] ReadData(string fileName)
        {
            // TODO   implement this method.
            // It should read the file whose fileName has been passed and fill
            StreamReader reader = new StreamReader("input.txt");
            //We might use the line below
            //int count = System.IO.File.ReadAllLines("file.txt").Length
            List<Student> students = new List<Student>();
            while (!reader.EndOfStream)
            {
                students.Add(new Student(reader.ReadLine()));
            }
            reader.Close();
            return students.ToArray();
        }

        static void Main(string[] args)
        {
            Student[] studs = ReadData("input.txt");
            
            Console.ReadKey();
        }
    }
}
