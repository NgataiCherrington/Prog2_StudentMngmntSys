using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class Learner : Person
    {
        private CourseAssessmentMark courseAssessmentMarks;

        public Learner (int id, string firstName, string lastName, CourseAssessmentMark courseAssessmentMarks) : base (id, firstName, lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.courseAssessmentMarks = courseAssessmentMarks;
        }

        public CourseAssessmentMark CourseAssessmentMarks { get => courseAssessmentMarks; set => courseAssessmentMarks = value; }
       
    }
}
