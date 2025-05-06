using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class Learner : Person
    {
        private CourseAssessmentMark courseAssessmentMarks;
        private int attendance;

        public Learner (int id, string firstName, string lastName, CourseAssessmentMark courseAssessmentMarks) : base (id, firstName, lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.courseAssessmentMarks = courseAssessmentMarks;
        }

        public Learner (int id, string firstName, string lastName, int attendance)  : base (id, firstName, lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Attendance = attendance;
        }

        public CourseAssessmentMark CourseAssessmentMarks { get => courseAssessmentMarks; set => courseAssessmentMarks = value; }
        public int Attendance { get => attendance; set => attendance = value; }
    }
}
