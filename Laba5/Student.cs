using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Laba5
{
    struct Student
    {
        public string surName;
        public string firstName;
        public string patronymic;
        public char sex;
        public string dateOfBirth;
        public char mathematicsMark;
        public char physicsMark;
        public char informaticsMark;
        public int scholarship;

        public Student(string lineWithAllData)
        {
            string[] entries = Regex.Split(lineWithAllData, @"\s+");
            surName = entries[0];
            firstName = entries[1];
            patronymic = entries[2];
            sex = Convert.ToChar(entries[3]);
            dateOfBirth = entries[4];
            mathematicsMark = Convert.ToChar(entries[5]);
            physicsMark = Convert.ToChar(entries[6]);
            informaticsMark = Convert.ToChar(entries[7]);
            scholarship = Convert.ToInt32(entries[8]);
            // TODO   you SHOULD IMPLEMENT constructor with exactly this signature
            // lineWithAllData is string contating all data about one student, as described in statement
        }
    }
}
