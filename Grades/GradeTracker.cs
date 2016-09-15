using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public interface IGradeTracker
    {
         event NamedChangedDelegate NameChanged;
         string Name { get; set; }
         void AddGrade(float grade);
         GradeStatistics ComputeStatistics();
    }
    public abstract class GradeTracker:IGradeTracker
    {
        public string _name;

        public event NamedChangedDelegate NameChanged;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("Name can not be null or empty");
                    }
                    var oldValue = _name;
                    _name = value;
                    if (NameChanged != null)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.OldValue = oldValue;
                        args.NewValue = value;
                        NameChanged(this, args);
                    }
                }
            }
        }
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();

    }
}
