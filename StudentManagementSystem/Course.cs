using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class Course
    {
        private Department department;
        private string code, name, description;
        private int credits;
        private double fees;
        public Course(Department department, string code, string name, string description, int credits, double fees)
        {
            this.department = department;
            this.code = code;
            this.name = name;
            this.description = description;
            this.credits = credits;
            this.fees = fees;
        }

        public Department Department { get => department; set => department = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int Credits { get => credits; set => credits = value; }
        public double Fees { get => fees; set => fees = value; }

        public string DisplayInfo() => $"Department:\t\t{department.Name}\nCourse code:\t\t{code}\nCourse name:\t\t{name}\nCourse description:\t{description}\nCourse credits:\t\t{credits}\nCourse fees:\t\t{fees}";
        public string DisplayCodeName() => $"{code}: {name}";

    }
}
