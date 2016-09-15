using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook:GradeTracker
    {     
        protected List<float> _grades;        

        public GradeBook(string name = "no Name")
        {
            Console.WriteLine("GradeBook contructor");
            _name = name;
            _grades = new List<float>();
        }
       
        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                _grades.Add(grade);
            }
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook compute");

            GradeStatistics stats = new GradeStatistics();
            float sum = 0.0f;

            foreach (float grade in _grades)
            {
                stats.HigestGrade = Math.Max(grade, stats.HigestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / _grades.Count;
            return stats;
        }
    }
}
