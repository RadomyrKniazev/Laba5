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
            double[] subjectsMarks = FindMiddleSubjectMark(studs);
            FindStudentWithMiddleMarkMoreThanTotal(studs, subjectsMarks);
            Console.ReadKey();
        }

        private static double[] FindMiddleSubjectMark(Student[] studs)
        {
            bool isNum = true;
            double[] subjectsMarks = new double[3];
            for (int i = 0; i < studs.Length; i++)
            {
                if (Char.IsDigit(studs[i].mathematicsMark) == isNum) {
                    subjectsMarks[0] += Char.GetNumericValue(studs[i].mathematicsMark); //m
                }                                                                       //a
                else                                                                    //t
                {                                                                       //h
                    subjectsMarks[0] += 0;
                }
                if (Char.IsDigit(studs[i].physicsMark) == isNum)                        //p
                {                                                                       //h
                    subjectsMarks[1] += Char.GetNumericValue(studs[i].physicsMark);     //y
                }                                                                       //s
                else                                                                    //i
                {                                                                       //c
                    subjectsMarks[1] += 0;                                              //s                       
                }
                if (Char.IsDigit(studs[i].informaticsMark) == isNum)                    //i
                {                                                                       //n                
                    subjectsMarks[2] += Char.GetNumericValue(studs[i].informaticsMark); //f
                }                                                                       //o        
                else                                                                    //r
                {                                                                       //m            
                    subjectsMarks[2] += 0;                                              //a            
                }                                                                       //tics    
                if(i + 1 == studs.Length)
                {
                    subjectsMarks[0] /= studs.Length;
                    subjectsMarks[1] /= studs.Length;
                    subjectsMarks[2] /= studs.Length;
                    Console.WriteLine("Middle math mark: {0}; middle physics mark: {1}; middle informatics mark: {2}", subjectsMarks[0], subjectsMarks[1], subjectsMarks[2]);
                }
            }
            return subjectsMarks;
        }

        private static void FindStudentWithMiddleMarkMoreThanTotal(Student[] studs, double[] subjectsMarks)
        {
            double middleMark = 0;
            middleMark = (subjectsMarks[0] + subjectsMarks[1] + subjectsMarks[2]) / 3;
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

            Console.WriteLine("Total middle mark: " + middleMark);
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
