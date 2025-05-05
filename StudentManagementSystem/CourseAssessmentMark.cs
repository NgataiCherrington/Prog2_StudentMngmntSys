using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class CourseAssessmentMark
    {
        private Course course;
        private List<int> assessmentMarks;

        public CourseAssessmentMark(Course course, List<int> assessmentMarks)
        {
            this.course = course;
            this.assessmentMarks = assessmentMarks;
        }

        public Course Course { get => course; set => course = value; }
        public List<int> AssessmentMarks { get => assessmentMarks; set => assessmentMarks = value; }
        
        public List<int> GetAllMarks()
        {
            return assessmentMarks;
        }

        public List<string> GetAllGrades()
        {
            List<string> gradedMarks = new List<string>();

            foreach (var score in assessmentMarks)
            {
                if (score >= 90)
                {
                    gradedMarks.Add("A+");
                }
                else if (score >= 85)
                {
                    gradedMarks.Add("A");
                }
                else if (score >= 80)
                {
                    gradedMarks.Add("A-");
                }
                else if (score >= 75)
                {
                    gradedMarks.Add("B+");
                }
                else if (score >= 70)
                {
                    gradedMarks.Add("B");
                }
                else if (score >= 65)
                {
                    gradedMarks.Add("B-");
                }
                else if (score >= 60)
                {
                    gradedMarks.Add("C+");
                }
                else if (score >= 55)
                {
                    gradedMarks.Add("C");
                }
                else if (score >= 50)
                {
                    gradedMarks.Add("C-");
                }
                else if (score >= 40)
                {
                    gradedMarks.Add("D");
                }
                else if (score >= 0)
                {
                    gradedMarks.Add("E");
                }
                else
                {
                    gradedMarks.Add("Error Occurred!");
                }
            }
            return gradedMarks;
        }

        public List<int> GetHighestMarks()
        {
            List<int> highestMarks = new List<int>();
            int maxMark = assessmentMarks.Max();

            foreach (int mark in assessmentMarks)
            {
                if (mark == maxMark)
                {
                    highestMarks.Add(mark);
                }
            }

            return highestMarks;
        }

        public List<int> GetLowestMarks()
        {
            List<int> lowestMarks = new List<int>();

            foreach (var mark in assessmentMarks)
            {
                if (mark >= 50 && mark <= 54)
                {
                    lowestMarks.Add(mark);
                }
            }

            return lowestMarks;
        }
        public List<int> GetFailMarks()
        {
            List<int> failMarks = new List<int>();

            foreach (var mark in assessmentMarks)
            {
                if (mark <= 49)
                {
                    failMarks.Add(mark);
                }
            }
            return failMarks;
        }
        public double GetAverageMarks()
        {
            double averageMarks = assessmentMarks.Average();
         
            return averageMarks;
        }
        public string GetAverageGrade()
        {
          
            double averageMarks = assessmentMarks.Average();
            if (assessmentMarks.Count == 0)
            {
                return "No grades available";
            }

            string averageGrade;
            if (averageMarks >= 90)
            {
                averageGrade = "A+";
            }
            else if (averageMarks >= 85)
            {
                averageGrade = "A";
            }
            else if (averageMarks >= 80)
            {
                averageGrade = "A-";
            }
            else if (averageMarks >= 75)
            {
                averageGrade = "B+";
            }
            else if (averageMarks >= 70)
            {
                averageGrade = "B";
            }
            else if (averageMarks >= 65)
            {
                averageGrade = "B-";
            }
            else if (averageMarks >= 60)
            {
                averageGrade = "C+";
            }
            else if (averageMarks >= 55)
            {
                averageGrade = "C";
            }
            else if (averageMarks >= 50)
            {
                averageGrade = "C-";
            }
            else if (averageMarks >= 40)
            {
                averageGrade = "D";
            }
            else
            {
                averageGrade = "E";
            }
            

            return averageGrade;
        }
    }
}
