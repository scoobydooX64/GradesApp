﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            HigestGrade = 0;
            LowestGrade = float.MaxValue;
        }

        public float AverageGrade;
        public float HigestGrade;
        public float LowestGrade;
    }
}
