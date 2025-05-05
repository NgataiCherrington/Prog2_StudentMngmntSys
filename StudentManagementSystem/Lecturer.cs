using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class Lecturer : Person
    {
        public enum EPosition
        {
            LECTURER = 0,
            SENIOR_LECTURER = 1,
            PRINCIPAL_LECTURER = 2,
            ASSOCIATE_PROFESSOR = 3,
            PROFESSOR = 4
        }

        public enum ESalary
        {
            LECTURER_SALARY = 85000,
            SENIOR_LECTURER_SALARY = 100000,
            PRINCIPAL_LECTURER_SALARY = 115000,
            ASSOCIATE_PROFESSOR_SALARY = 130000,
            PROFESSOR_SALARY = 145000
        }

        private EPosition position;
        private ESalary salary;
        private Course course;

        public Lecturer (int id, string firstName, string lastName, EPosition position, ESalary salary, Course course) : base (id, lastName, firstName)
        {
            this.position = position;
            this.salary = salary;
            this.course = course;
        }

        public EPosition Position { get => position; set => position = value; }
        public ESalary Salary { get => salary; set => salary = value; }
        public Course Course { get => course; set => course = value; }
    }
}
