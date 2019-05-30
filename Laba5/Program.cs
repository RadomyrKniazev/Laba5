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
            double middleMark = FindMiddleMark(studs);
            FindStudentWithMiddleMarkMoreThanTotal(studs, middleMark);
            Console.ReadKey();
        }

        private static double FindMiddleMark(Student[] studs)
        {
            double middleMark = 0;
            bool isNum = true;
            for (int i = 0; i < studs.Length; i++)
            {
                double math = 0;
                double physics = 0;
                double inf = 0;
                if (Char.IsDigit(studs[i].mathematicsMark) == isNum) {  
                    math += Char.GetNumericValue(studs[i].mathematicsMark);
                }
                else
                {
                    math += 0;
                }
                if (Char.IsDigit(studs[i].physicsMark) == isNum)
                { 
                    physics += Char.GetNumericValue(studs[i].physicsMark);
                }
                else
                {
                    physics += 0;
                }
                if (Char.IsDigit(studs[i].informaticsMark) == isNum)
                {
                    inf += Char.GetNumericValue(studs[i].informaticsMark);
                }
                else
                {
                    inf += 0;
                }
                middleMark += (math + physics + inf);
                if(i + 1 == studs.Length)
                {
                    middleMark /= (3 * studs.Length);
                    Console.WriteLine("Middle mark of all students: {0}", middleMark);
                }
            }
            return middleMark;
        }

        private static void FindStudentWithMiddleMarkMoreThanTotal(Student[] studs, double middleMark)
        {
            double studentMiddleMark = 0;
            bool isNum = true;
            double[] studentsMiddleMark = new double[studs.Length];
            for (int i = 0; i < studs.Length; i++)
            {
                double math = 0;
                double physics = 0;
                double inf = 0;
                if (Char.IsDigit(studs[i].mathematicsMark) == isNum)
                {
                    math = Char.GetNumericValue(studs[i].mathematicsMark);
                }
                else
                {
                    math = 0;
                }
                if (Char.IsDigit(studs[i].physicsMark) == isNum)
                {
                    physics = Char.GetNumericValue(studs[i].physicsMark);
                }
                else
                {
                    physics = 0;
                }
                if (Char.IsDigit(studs[i].informaticsMark) == isNum)
                {
                    inf = Char.GetNumericValue(studs[i].informaticsMark);
                }
                else
                {
                    inf = 0;
                }
                studentMiddleMark = (math + physics + inf) / 3;
                studentsMiddleMark[i] = studentMiddleMark;
            }

            for (int i = 0; i < studs.Length; i++)
            {
                if(studentsMiddleMark[i] > middleMark)
                {
                    Console.WriteLine("Surname: " + studs[i].surName + ", middle mark: " + studentsMiddleMark[i]);
                }
            }
        }
    }
}
