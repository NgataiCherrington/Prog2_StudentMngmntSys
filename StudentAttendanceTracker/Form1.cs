using StudentManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentAttendanceTracker
{
    public partial class Form1 : Form
    {
        // Static list to store all available courses in the application
        private static List<Course> courses;

        // Static list to store all learners, shared across the application
        private static List<Learner> learners;

        public Form1()
        {
            // Initialize form components and set up learner list
            InitializeComponent();
            learners = new List<Learner>();

            // Read learner data (including attendance) from file
            ReadFromFile("attendance.txt", learners, true);

            // Create and set up the data table for displaying learner attendance
            DataTable learnerAttendanceTable = new DataTable();
            learnerAttendanceTable.Columns.Clear();
            learnerAttendanceTable.Columns.Add("ID");
            learnerAttendanceTable.Columns.Add("Name");
            learnerAttendanceTable.Columns.Add("Percentage");

            // Check if any learners were loaded from the file
            if (learners == null || learners.Count == 0)
            {
                MessageBox.Show("No learners found!", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Loop through each learner and add their data to the table
                foreach (Learner learner in learners)
                {
                    string name = $"{learner.FirstName} {learner.LastName}";
                    var row = learnerAttendanceTable.NewRow();
                    row["ID"] = learner.DisplayPersonId(); // Custom method to display learner ID
                    row["Name"] = name;
                    row["percentage"] = learner.Attendance;  // Fill in attendance percentage

                    learnerAttendanceTable.Rows.Add(row);

                    // Add learners with attendance below 50% to a separate list for highlighting
                    if (learner.Attendance < 50)
                    {
                        listBox1.Items.Add(name);
                    }
                }            
            }

            // Bind the populated data table to the DataGridView for display
            dataGridView1.DataSource = learnerAttendanceTable;

            // Prevent editing in the grid
            dataGridView1.ReadOnly = true; 

            
        }

        public static void ReadFromFile(string filePath, List<Learner> learners, bool isAttendance)
        {
            // Create variable containing attendance file and store each line in a list
            filePath = "attendance.txt";
            List<string> lines = File.ReadAllLines(filePath).ToList();

            // Split each line from the file into separate pieces of learner data
            foreach (string line in lines)
            {
                string[] learnerDetails = line.Split(',');

                // Parse the learner's basic information
                int id = int.Parse(learnerDetails[0]);
                string firstName = learnerDetails[1];
                string lastName = learnerDetails[2];
                int courseNum = int.Parse(learnerDetails[3]);
                Learner learner = null;

                if (isAttendance)
                {
                    // If reading attendance data, parse attendance percentage
                    int percentage = int.Parse(learnerDetails[4]);
                    learner = new Learner(id, firstName, lastName, percentage); // Create learner with attendance info
                }

                else
                {
                    // If reading marks data, parse five assessment marks
                    List<int> marks = new List<int>()
                    {
                        Convert.ToInt32(learnerDetails[4]),
                        Convert.ToInt32(learnerDetails[5]),
                        Convert.ToInt32(learnerDetails[6]),
                        Convert.ToInt32(learnerDetails[7]),
                        Convert.ToInt32(learnerDetails[8]),
                    };

                    // Associate the marks with the correct course
                    CourseAssessmentMark assessmentMark = new CourseAssessmentMark(courses[courseNum], marks);

                    // Create learner with course assessment data
                    learner = new Learner(id, firstName, lastName, assessmentMark);

                }

                // Add the learner object to the main learners list
                learners.Add(learner);
            }
        }
    }
}
