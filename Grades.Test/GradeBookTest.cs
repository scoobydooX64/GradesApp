using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grades;

namespace Grades.Test
{
    [TestClass]
    public class GradeBookTest
    {
        [TestMethod]
        public void TestHigestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(90f);
            book.AddGrade(30f);
            book.AddGrade(60f);

            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(90f,stats.HigestGrade);

        }
    }
}
