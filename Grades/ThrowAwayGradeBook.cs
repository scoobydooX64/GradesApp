using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public ThrowAwayGradeBook(string name):base(name)
        {
            Console.WriteLine("Throw GradeBook away contructor");
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("Throw awaya GradeBook compute");

            float lowest = float.MaxValue;

            foreach (var grade in _grades)
            {
                lowest = Math.Min(grade, lowest);
            }

            _grades.Remove(lowest);

            return base.ComputeStatistics();
        }
    }
}
