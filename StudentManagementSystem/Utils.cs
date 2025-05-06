using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public class Utils
    {
        public static List<Institution> institutions = new List<Institution>();
        public static List<Department> departments = new List<Department>();
        public static List<Course> courses = new List<Course>();

        public static List<Institution> SeedInstitutions()
        {
            institutions.Add(new Institution("Otago Polytechnic", "Otago", "New Zealand"));
            institutions.Add(new Institution("University of Auckland", "Auckland", "New Zealand"));
            institutions.Add(new Institution("Auckland University of Technology", "Auckland", "New Zealand"));

            return institutions;
        }

        public static List<Department> SeedDepartments()
        {
            departments.Add(new Department(institutions[0], "Psychology"));
            departments.Add(new Department(institutions[1], "Information Technology"));
            departments.Add(new Department(institutions[2], "History"));

            return departments;
        }

        public static List<Course> SeedCourses()
        {
            courses.Add(new Course(departments[0], "PSY 101", "Intro to Psychology", "Basic psychological principles", 3, 500.00));
            courses.Add(new Course(departments[1], "IT 202", "Data Structures", "Organizing data efficiently", 4, 500.00));
            courses.Add(new Course(departments[2], "HIS 305", "Ancient Civilizations", "Early human societies", 3, 500.00));

            return courses;
        }

        public static void ReadFromLearnerFile(string filePath, List<Learner> learners, bool isAttendance)
        {
            filePath = "learners.txt";
            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (string line in lines)
            {
                string[] learnerDetails = line.Split(',');

                int id = int.Parse(learnerDetails[0]);
                string firstName = learnerDetails[1];
                string lastName = learnerDetails[2];
                int courseNum = int.Parse(learnerDetails[3]);
                Learner learner = null;

                if (isAttendance)
                {
                    int percentage = int.Parse(learnerDetails[4]);
                    learner = new Learner(id, firstName, lastName, percentage);
                }

                else
                {
                    List<int> marks = new List<int>()
                    {
                        Convert.ToInt32(learnerDetails[4]),
                        Convert.ToInt32(learnerDetails[5]),
                        Convert.ToInt32(learnerDetails[6]),
                        Convert.ToInt32(learnerDetails[7]),
                        Convert.ToInt32(learnerDetails[8]),
                    };

                    CourseAssessmentMark assessmentMark = new CourseAssessmentMark(courses[courseNum], marks);

                    learner = new Learner(id, firstName, lastName, assessmentMark);

                }

                learners.Add(learner);
            }
        }

        public static void ReadFromLecturerFile(string filePath, List<Lecturer> lecturers)
        {
            filePath = "lecturers.txt";
            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (string line in lines)
            {
                string[] lecturerDetails = line.Split(',');

                int id = int.Parse(lecturerDetails[0]);
                string firstName = lecturerDetails[1];
                string lastName = lecturerDetails[2];
                Lecturer.EPosition position = (Lecturer.EPosition)Enum.Parse(typeof(Lecturer.EPosition), lecturerDetails[3].Trim(), true);
                Lecturer.ESalary salary = (Lecturer.ESalary)Enum.Parse(typeof(Lecturer.ESalary), lecturerDetails[4].Trim(), true);
                int courseID = int.Parse(lecturerDetails[5]);

                Lecturer lecturer = new Lecturer(id, firstName, lastName, position, salary, courses[courseID]);

                lecturers.Add(lecturer);
            }

        }
    }
}
