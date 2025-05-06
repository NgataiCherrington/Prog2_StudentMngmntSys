using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static StudentManagementSystem.Lecturer;

namespace StudentManagementSystem
{
    

    public partial class Form1 : Form
    {
        List<int> highestMarks = new List<int>();
        private static List<Department> departments = new List<Department>();
        private static List<Institution> institutions = new List<Institution>();
        private static List<Course> courses;
        private static List<Learner> learners;
        private static List<Lecturer> lecturers;
        

        public Form1()
        {
            InitializeComponent();

            institutions = Utils.SeedInstitutions();
            departments = Utils.SeedDepartments();
            courses = Utils.SeedCourses();
            learners = new List<Learner>();
            lecturers = new List<Lecturer>();
            Utils.ReadFromLearnerFile("learners.txt", learners, false);
            Utils.ReadFromLecturerFile("lecturers.txt", lecturers);      
            
            foreach (var item in courses)
            {
                courseComboBox.Items.Add(item.Name);

            }

            foreach (var item in lecturers)
            {
                positionComboBox.Items.Add(item.Position);
            }

        }

        private void ToggleControls(bool showDataGridView)
        {
            if (showDataGridView)
            {
                dataGridView1.Visible = true;

                firstNameTextBox.Visible = false;
                lastNameTextBox.Visible = false;
                courseComboBox.Visible = false;
                positionComboBox.Visible = false;
                idTextBox.Visible = false;
                mark1TextBox.Visible = false;
                mark2TextBox.Visible = false;
                mark3TextBox.Visible = false;
                mark4TextBox.Visible = false;
                mark5TextBox.Visible = false;
                saveButton.Visible = false;
                saveLecturerBtn.Visible = false;
                checkBtn.Visible = false;


                label2.Visible = false; // First Name label
                label3.Visible = false; // Last Name label
                label4.Visible = false; // Course label
                label5.Visible = false; // Mark 1 label
                label6.Visible = false; // Mark 2 label
                label7.Visible = false; // Mark 3 label
                label8.Visible = false; // Mark 4 label
                label9.Visible = false; // Mark 5 label
                label10.Visible = false; // Position label  
                label11.Visible = false; // Search ID label
            }
            else
            {
                dataGridView1.Visible = false;

                firstNameTextBox.Visible = true;
                lastNameTextBox.Visible = true;
                courseComboBox.Visible = true;
                positionComboBox.Visible = false;
                idTextBox.Visible = false;
                mark1TextBox.Visible = true;
                mark2TextBox.Visible = true;
                mark3TextBox.Visible = true;
                mark4TextBox.Visible = true;
                mark5TextBox.Visible = true;
                saveButton.Visible = true;
                saveLecturerBtn.Visible = false;
                checkBtn.Visible = false;

                label2.Visible = true; // First Name label
                label3.Visible = true; // Last Name label
                label4.Visible = true; // Course label
                label5.Visible = true; // Mark 1 label
                label6.Visible = true; // Mark 2 label
                label7.Visible = true; // Mark 3 label
                label8.Visible = true; // Mark 4 label
                label9.Visible = true; // Mark 5 label
                label10.Visible = false; // Position label
                label11.Visible = false; // Search ID label
            }
        }   

        private void ToggleLecturerControls(bool showDataGridView)
        {
            if (showDataGridView)
            {
                dataGridView1.Visible = true;

                firstNameTextBox.Visible = false;
                lastNameTextBox.Visible = false;
                courseComboBox.Visible = false;
                mark1TextBox.Visible = false;
                mark2TextBox.Visible = false;
                mark3TextBox.Visible = false;
                mark4TextBox.Visible = false;
                mark5TextBox.Visible = false;
                saveButton.Visible = false;

                label2.Visible = false; // First Name label
                label3.Visible = false; // Last Name label
                label4.Visible = false; // Course label
            }
            else
            {
                dataGridView1.Visible = false;

                firstNameTextBox.Visible = true;
                lastNameTextBox.Visible = true;
                courseComboBox.Visible = true;
                positionComboBox.Visible = true;
                idTextBox.Visible = false;
                mark1TextBox.Visible = false;
                mark2TextBox.Visible = false;
                mark3TextBox.Visible = false;
                mark4TextBox.Visible = false;
                mark5TextBox.Visible = false;
                saveLecturerBtn.Visible = true;
                saveButton.Visible = false;
                checkBtn.Visible = false;

                label2.Visible = true; // First Name label
                label3.Visible = true; // Last Name label
                label4.Visible = true; // Course label
                label5.Visible = false; // Mark 1 label
                label6.Visible = false; // Mark 2 label
                label7.Visible = false; // Mark 3 label
                label8.Visible = false; // Mark 4 label
                label9.Visible = false; // Mark 5 label
                label10.Visible = true; // Position label
                label11.Visible = false; // Search ID label
            }
        }

        private void ToggleRmvLecturerControls(bool showDataGridView)
        {
            if (showDataGridView)
            {
                dataGridView1.Visible = true;

                firstNameTextBox.Visible = false;
                lastNameTextBox.Visible = false;
                courseComboBox.Visible = false;
                mark1TextBox.Visible = false;
                mark2TextBox.Visible = false;
                mark3TextBox.Visible = false;
                mark4TextBox.Visible = false;
                mark5TextBox.Visible = false;
                saveButton.Visible = false;

                label2.Visible = false; // First Name label
                label3.Visible = false; // Last Name label
                label4.Visible = false; // Course label
            }
            else
            {
                dataGridView1.Visible = false;

                firstNameTextBox.Visible = false;
                lastNameTextBox.Visible = false;
                courseComboBox.Visible = false;
                positionComboBox.Visible = false;
                idTextBox.Visible = true;
                mark1TextBox.Visible = false;
                mark2TextBox.Visible = false;
                mark3TextBox.Visible = false;
                mark4TextBox.Visible = false;
                mark5TextBox.Visible = false;
                saveLecturerBtn.Visible = false;
                checkBtn.Visible = true;
                saveButton.Visible = false;

                label2.Visible = false; // First Name label
                label3.Visible = false; // Last Name label
                label4.Visible = false; // Course label
                label5.Visible = false; // Mark 1 label
                label6.Visible = false; // Mark 2 label
                label7.Visible = false; // Mark 3 label
                label8.Visible = false; // Mark 4 label
                label9.Visible = false; // Mark 5 label
                label10.Visible = false; // Position label
                label11.Visible = true; // Search ID label
            }
        }

        private void ClearInputFields()
        {
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            courseComboBox.Text = "";
            positionComboBox.Text = "";
            idTextBox.Text = "";
            mark1TextBox.Text = "";
            mark2TextBox.Text = "";
            mark3TextBox.Text = "";
            mark4TextBox.Text = "";
            mark5TextBox.Text = "";
        }

        private void DisplayCourseDetail_btn(object sender, EventArgs e)
        {
            // Create and set up a new DataTable to hold course details
            DataTable courseDataTable = new DataTable();
            courseDataTable.Columns.Clear();
            courseDataTable.Columns.Add("Course");
            courseDataTable.Columns.Add("Description");
            courseDataTable.Columns.Add("Credits");
            courseDataTable.Columns.Add("Fees");


            // Populate the table by looping through the list of Course objects
            foreach (Course course in courses)
            {
                var row = courseDataTable.NewRow();
                row["Course"] = course.DisplayCodeName(); // Custom method combines code and name
                row["Description"] = course.Description;
                row["Credits"] = course.Credits;
                row["Fees"] = course.Fees;

                courseDataTable.Rows.Add(row); // Add the filled row to the table
            }

            // Bind the populated DataTable to the DataGridView for display
            dataGridView1.DataSource = courseDataTable;

            // Make the DataGridView read-only to prevent user editing
            dataGridView1.ReadOnly = true;

            // Enable or disable other UI controls as needed
            ToggleControls(true);
        }

        private void DisplayAllMarks_btn(object sender, EventArgs e)
        {
            // Create and set up a new DataTable to hold learner details
            DataTable learnerDataTable = new DataTable();
            learnerDataTable.Clear();
            learnerDataTable.Columns.Add("ID");
            learnerDataTable.Columns.Add("Name"); 
            learnerDataTable.Columns.Add("Mark 1");
            learnerDataTable.Columns.Add("Mark 2");
            learnerDataTable.Columns.Add("Mark 3");
            learnerDataTable.Columns.Add("Mark 4");
            learnerDataTable.Columns.Add("Mark 5");

            // Populate the table by looping through the list of Learner objects
            foreach (var learner in learners)
            {
                List<int> marks = new List<int>(learner.CourseAssessmentMarks.GetAllMarks()); // Create a new list of integers containing all assessment marks from the learner's course
                string name = $"{learner.FirstName} {learner.LastName}";
                var row = learnerDataTable.NewRow();
                row["ID"] = learner.Id;
                row["Name"] = name;
                for (int i = 0; i < 5; i++)
                {
                    row[$"Mark {i + 1}"] = marks.Count > i ? marks[i] : 0; // Add a mark to the row for "Mark {i+1}"; if the mark doesn't exist (i exceeds mark count), default to 0
                }
                learnerDataTable.Rows.Add(row); // Add the filled row to the table
            }

            // Bind the populated DataTable to the DataGridView for display
            dataGridView1.DataSource = learnerDataTable;

            // Make the DataGridView read-only to prevent user editing
            dataGridView1.ReadOnly = true;

            // Enable or disable other UI controls as needed
            ToggleControls(true);
        }

        private void DisplayAllGrades_btn(object sender, EventArgs e)
        {
            // Create and set up a new DataTable to hold grade details
            DataTable gradeDataTable = new DataTable();
            gradeDataTable.Clear();
            gradeDataTable.Columns.Add("ID");
            gradeDataTable.Columns.Add("Name");
            gradeDataTable.Columns.Add("Code");
            gradeDataTable.Columns.Add("Grade 1");
            gradeDataTable.Columns.Add("Grade 2");
            gradeDataTable.Columns.Add("Grade 3");
            gradeDataTable.Columns.Add("Grade 4");
            gradeDataTable.Columns.Add("Grade 5");

            // Populate the table by looping through the list of Learner objects
            foreach (var learner in learners)
            {
                List<string> marks = new List<string>(learner.CourseAssessmentMarks.GetAllGrades()); // Create a new list of strings containing all assessment grades from the learner's course

                string name = $"{learner.FirstName} {learner.LastName}";
                var row = gradeDataTable.NewRow();
                row["ID"] = learner.Id;
                row["Name"] = name;
                row["Code"] = learner.CourseAssessmentMarks.Course.DisplayCodeName(); // Custom method combines code and name               
                for (int i = 0; i < 5; i++)
                {                  
                    row[$"Grade {i + 1}"] = marks.Count > i ? marks[i] : "N/A"; // Add a grade to the row for "Grade {i+1}"; if the grade doesn't exist (i exceeds count), default to N/A
                }
                gradeDataTable.Rows.Add(row); // Add the filled row to the table
            }


            // Bind the populated DataTable to the DataGridView for display
            dataGridView1.DataSource = gradeDataTable;

            // Make the DataGridView read-only to prevent user editing
            dataGridView1.ReadOnly = true;

            // Enable or disable other UI controls as needed
            ToggleControls(true);

        }

        private void DisplayHighestMarks_btn(object sender, EventArgs e)
        {
            // Create and set up a new DataTable to hold learner highest marks detail
            DataTable highestMarkTable = new DataTable();
            highestMarkTable.Columns.Clear();
            highestMarkTable.Columns.Add("ID");
            highestMarkTable.Columns.Add("Name");
            highestMarkTable.Columns.Add("Course");
            highestMarkTable.Columns.Add("Highest Mark");

            foreach (var learner in learners)
            {
                List<int> marks = new List<int>(learner.CourseAssessmentMarks.GetHighestMarks()); // Create a new list of integers containing all assessment highest marks from the learner's course
                string name = $"{learner.FirstName} {learner.LastName}";
                var row = highestMarkTable.NewRow();
                row["ID"] = learner.Id;
                row["Name"] = name;
                row["Course"] = learner.CourseAssessmentMarks.Course.DisplayCodeName(); // Custom method combines code and name
                row["Highest Mark"] = string.Join(", ", marks);

                highestMarkTable.Rows.Add(row);  // Add the filled row to the table
            }

            // Bind the populated DataTable to the DataGridView for display
            dataGridView1.DataSource = highestMarkTable;

            // Make the DataGridView read-only to prevent user editing
            dataGridView1.ReadOnly = true;

            // Enable or disable other UI controls as needed
            ToggleControls(true);
        }

        private void DisplayLowestMarks_btn(object sender, EventArgs e)
        {
            // Create and set up a new DataTable to hold learner lowest passing marks detail
            DataTable lowestMarkTable = new DataTable();
            lowestMarkTable.Columns.Clear();
            lowestMarkTable.Columns.Add("ID");
            lowestMarkTable.Columns.Add("Name");
            lowestMarkTable.Columns.Add("Code");
            lowestMarkTable.Columns.Add("Lowest Mark");

            foreach (var  learner in learners)
            {
                List<int> marks = new List<int>(learner.CourseAssessmentMarks.GetLowestMarks()); // Create a new list of integers containing all assessment lowest passing marks from the learner's course
                string name = $"{learner.FirstName} {learner.LastName}";
                var row = lowestMarkTable.NewRow();
                row["ID"] = learner.Id;
                row["Name"] = name;
                row["Code"] = learner.CourseAssessmentMarks.Course.DisplayCodeName(); // Custom method to display code and name

                if (!marks.Any(mark => mark <= 50)) // Check if all marks are above 50; if so, there is no 'low' mark, so set the field to "N/A"
                {
                    row["Lowest Mark"] = "N/A";
                }
                else // Otherwise, display the lowest mark that is 50 or below
                {
                    row["Lowest Mark"] = string.Join(", ", marks); 
                }

                
                lowestMarkTable.Rows.Add(row); // Add the filled row to the table
            }

            // Bind the populated DataTable to the DataGridView for display
            dataGridView1.DataSource = lowestMarkTable;

            // Make the DataGridView read-only to prevent user editing
            dataGridView1.ReadOnly = true;

            // Enable or disable other UI controls as needed
            ToggleControls(true);
        }
        

        private void DisplayFailMarks_btn(object sender, EventArgs e)
        {
            // Create and set up a new DataTable to hold learner failing marks detail
            DataTable failMarkTable = new DataTable();
            failMarkTable.Columns.Clear();
            failMarkTable.Columns.Add("ID");
            failMarkTable.Columns.Add("Name");
            failMarkTable.Columns.Add("Code");
            failMarkTable.Columns.Add("Fail Mark");

            foreach (var learner in learners)
            {
                List<int> marks = new List<int>(learner.CourseAssessmentMarks.GetFailMarks());  // Create a new list of integers containing all assessment failing marks from the learner's course
                string name = $"{learner.FirstName} {learner.LastName}";
                var row = failMarkTable.NewRow();
                row["ID"] = learner.Id;
                row["Name"] = name;
                row["Code"] = learner.CourseAssessmentMarks.Course.DisplayCodeName(); // Custom method to display code and name

                if (!marks.Any(mark => mark <= 50)) // If there are no failing marks (50 or below), indicate that with "N/A"
                {
                    row["Fail Mark"] = "N/A";
                }
                else // Otherwise, display the failing marks 
                {
                    row["Fail Mark"] = string.Join(", ", marks);

                }


                failMarkTable.Rows.Add(row); // Add the filled row to the table
            }

            // Bind the populated DataTable to the DataGridView for display
            dataGridView1.DataSource = failMarkTable;

            // Make the DataGridView read-only to prevent user editing
            dataGridView1.ReadOnly = true;

            // Enable or disable other UI controls as needed
            ToggleControls(true);
        }

        private void DisplayAvgMarks_btn(object sender, EventArgs e)
        {
            // Create and set up a new DataTable to hold learner average marks detail
            DataTable avgMarkTable = new DataTable();
            avgMarkTable.Columns.Clear();
            avgMarkTable.Columns.Add("ID");
            avgMarkTable.Columns.Add("Name");
            avgMarkTable.Columns.Add("Code");
            avgMarkTable.Columns.Add("Average Mark");

            foreach(var learner in learners)
            {
                double avgMark = learner.CourseAssessmentMarks.GetAverageMarks(); // Create a variable of type double containing the calculated average mark
                string name = $"{learner.FirstName} {learner.LastName}";
                var row = avgMarkTable.NewRow();
                row["ID"] = learner.Id;
                row["Name"] = name;
                row["Code"] = learner.CourseAssessmentMarks.Course.DisplayCodeName(); // Custom method to display code and name
                row["Average Mark"] = avgMark;
                
                avgMarkTable.Rows.Add(row);  // Add the filled row to the table
            }

            // Bind the populated DataTable to the DataGridView for display
            dataGridView1.DataSource = avgMarkTable;

            // Make the DataGridView read - only to prevent user editing
            dataGridView1.ReadOnly = true;

            // Enable or disable other UI controls as needed
            ToggleControls(true);
        }

        private void DisplayAvgGrades_btn(object sender, EventArgs e)
        {
            // Create and set up a new DataTable to hold learner average grade detail
            DataTable avgGradeTable = new DataTable();
            avgGradeTable.Columns.Clear();
            avgGradeTable.Columns.Add("ID");
            avgGradeTable.Columns.Add("Name");
            avgGradeTable.Columns.Add("Code");
            avgGradeTable.Columns.Add("Average Grade");

            foreach(var learner in learners)
            {
                string avgGrade = learner.CourseAssessmentMarks.GetAverageGrade(); // Create a variable of type string containing the calcutated average grade
                string name = $"{learner.FirstName} {learner.LastName}";
                var row = avgGradeTable.NewRow();
                row["ID"] = learner.Id;
                row["Name"] = name;
                row["Code"] = learner.CourseAssessmentMarks.Course.DisplayCodeName(); // Custom method to display code and name
                row["Average Grade"] = avgGrade;

                avgGradeTable.Rows.Add(row); // Add the filled row to the table
            }

            // Bind the populated DataTable to the DataGridView for display
            dataGridView1.DataSource = avgGradeTable;

            // Make the DataGridView read - only to prevent user editing
            dataGridView1.ReadOnly = true;

            // Enable or disable other UI controls as needed
            ToggleControls(true);
        }

        private void DisplayLecturerDetails_btn(object sender, EventArgs e)
        {
            // Create and set up a new DataTable to hold lecturer details
            DataTable lecturerDetailTable = new DataTable();
            lecturerDetailTable.Columns.Clear();
            lecturerDetailTable.Columns.Add("ID");
            lecturerDetailTable.Columns.Add("Name");
            lecturerDetailTable.Columns.Add("Position");
            lecturerDetailTable.Columns.Add("Institution");
            lecturerDetailTable.Columns.Add("Department");
            lecturerDetailTable.Columns.Add("Course");
            lecturerDetailTable.Columns.Add("Salary");

            if (lecturers == null || lecturers.Count == 0) // If no lectures are found display debug message
            {
                MessageBox.Show("No lecturers found!", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else // Otherwise display the lecturer details
            {
                foreach (var lecturer in lecturers)
                {
                    string institutionDetails = lecturer.Course.Department.Institution.DisplayInfo(); // Create a variable of type string containing method to display institution details
                    string name = $"{lecturer.FirstName} {lecturer.LastName}";
                    var row = lecturerDetailTable.NewRow();
                    row["ID"] = lecturer.DisplayPersonId();
                    row["Name"] = name;
                    row["Position"] = lecturer.Position.ToString();
                    row["Institution"] = institutionDetails;
                    row["Department"] = lecturer.Course.Department.Name;
                    row["Course"] = lecturer.Course.DisplayCodeName(); // Create method to display code and name
                    row["Salary"] = (int)lecturer.Salary; 

                    lecturerDetailTable.Rows.Add(row); // Add the filled row to the table
                }

                // Bind the populated DataTable to the DataGridView for display
                dataGridView1.DataSource = lecturerDetailTable;

                // Make the DataGridView read - only to prevent user editing
                dataGridView1.ReadOnly = true;

                // Enable or disable other UI controls as needed
                ToggleControls(true);
            }         
        }

        private void AddLearner_btn(object sender, EventArgs e)
        {
            ToggleControls(false); // Enable or disable other UI controls as needed
        }

        private void AddLecturer_btn(object sender, EventArgs e)
        {
           ToggleLecturerControls(false); // Enable or disable other UI controls as needed
        }

        private void RemoveLecturer_btn(object sender, EventArgs e)
        {
            ToggleRmvLecturerControls(false); // Enable or disable other UI controls as needed
        }
        private void Exit_btn(object sender, EventArgs e)
        {
            Application.Exit(); // Exit application
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Declare StreamWriter for saving data to a file
            StreamWriter sw;
            string details = "";
            string filePath = "learners.txt";

            // Get values from input fields
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string specialCharacters = "! @ # $ % ^ & * ( )";
            int selectedIndex = courseComboBox.SelectedIndex;

            // Collect assessment marks from the text boxes
            string[] assessmentMarks = new string[5];
            assessmentMarks[0] = mark1TextBox.Text;
            assessmentMarks[1] = mark2TextBox.Text;
            assessmentMarks[2] = mark3TextBox.Text;
            assessmentMarks[3] = mark4TextBox.Text;
            assessmentMarks[4] = mark5TextBox.Text;

            // If all required fields are filled
            if (firstNameTextBox.Text.Trim() == "" || lastNameTextBox.Text.Trim() == "" || courseComboBox.SelectedIndex == -1 || mark1TextBox.Text.Trim() == "" || mark2TextBox.Text.Trim() == "" || mark3TextBox.Text.Trim() == "" || mark4TextBox.Text.Trim() == "" || mark5TextBox.Text.Trim() == "")
            {
                MessageBox.Show("Error, Please fill in all elements");
            }
            else
            {
                // If all marks are within the range 1–100
                if ((int.Parse(mark1TextBox.Text) <= 0 || int.Parse(mark1TextBox.Text) > 100) || (int.Parse(mark2TextBox.Text) <= 0 || int.Parse(mark2TextBox.Text) > 100) || (int.Parse(mark3TextBox.Text) <= 0 || int.Parse(mark3TextBox.Text) > 100) || (int.Parse(mark4TextBox.Text) <= 0 || int.Parse(mark4TextBox.Text) > 100) || (int.Parse(mark5TextBox.Text) <= 0 || int.Parse(mark5TextBox.Text) > 100))
                {
                    MessageBox.Show("Invalid, Please enter a number between 1-100");
                }

                // Else if names do not contain special characters
                else if (firstName.Any(c => specialCharacters.Contains(c)) || lastName.Any(c => specialCharacters.Contains(c)))
                {
                    MessageBox.Show("You can not use special Characters");
                    return;
                }

                else
                {
                    // Generate a new learner ID (incrementing from the max existing one or starting at 1)
                    int newLearnerId = (learners != null && learners.Any()) ? learners.Max(x => x.Id) + 1 : 1;

                    // Format the learner's data into a comma-separated string
                    details = newLearnerId + "," + firstName + "," + lastName + "," + selectedIndex + "," + assessmentMarks[0] + "," + assessmentMarks[1] + "," + assessmentMarks[2] + "," + assessmentMarks[3] + "," + assessmentMarks[4];

                    // Append the learner's details to the file
                    sw = new StreamWriter(filePath, append: true);
                    sw.WriteLine(details);
                    sw.Close();

                    // Convert mark strings to integers and create a new Learner object
                    List<int> marks = new List<int>()
                    {
                        Convert.ToInt32(assessmentMarks[0]),
                        Convert.ToInt32(assessmentMarks[1]),
                        Convert.ToInt32(assessmentMarks[2]),
                        Convert.ToInt32(assessmentMarks[3]),
                        Convert.ToInt32(assessmentMarks[4]),
                    };
                    Learner newLearner = new Learner(newLearnerId, firstName, lastName, new CourseAssessmentMark(courses[selectedIndex], marks));

                    // Add the new learner to the learner list
                    learners.Add(newLearner);
                }
            }

            // Notify the user and clear form inputs
            MessageBox.Show("New Learner Added!");
            ClearInputFields();
        }

        private void saveLecturerBtn_Click(object sender, EventArgs e)
        {
            // Declare StreamWriter for saving data to a file
            StreamWriter sw;
            string details = "";
            string filePath = "lecturers.txt";

            // Get values from input fields
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string specialCharacters = "! @ # $ % ^ & * ( )";
            EPosition selectedPosition = (EPosition)positionComboBox.SelectedItem;
            ESalary salary = (ESalary)Enum.Parse(typeof(ESalary), selectedPosition.ToString());
            int selectedCourseIndex = courseComboBox.SelectedIndex;

            // If all required fields are filled
            if (firstNameTextBox.Text.Trim() == "" || lastNameTextBox.Text.Trim() == "" || courseComboBox.SelectedIndex == -1 || positionComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all elements in!");
            }
            else
            {
                // If names do not contain special characters
                if (firstName.Any(c => specialCharacters.Contains(c)) || lastName.Any(c => specialCharacters.Contains(c)))
                {
                    MessageBox.Show("You can not use special Characters");
                    return;
                }

                else
                {
                    // Generate a new lecturer ID (incrementing from the max existing one or starting at 1)
                    int newLecturerId = (lecturers != null && lecturers.Any()) ? lecturers.Max(x => x.Id) + 1 : 1;

                    // Format the learner's data into a comma-separated string
                    details = newLecturerId + "," + firstName + "," + lastName + "," + selectedCourseIndex + ","  + (int)salary + "," + (int)selectedPosition;

                    // Append the learner's details to the file
                    sw = new StreamWriter(filePath, append: true);
                    sw.WriteLine(details);
                    sw.Close();

                    // Create new lecturer object and add new lecturer to the lecturer list
                    Lecturer newLecturer = new Lecturer(newLecturerId, firstName, lastName, selectedPosition, salary, courses[selectedCourseIndex]);
                    lecturers.Add(newLecturer);

                }
            }

            // Notify the user and clear form inputs
            MessageBox.Show("New Lecturer Added!");
            ClearInputFields();
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            // Get the ID to remove from the text box
            string removeId = idTextBox.Text;

            // Check if the ID field is empty
            if (string.IsNullOrEmpty(removeId))
            {
                MessageBox.Show("Please fill all elements in!");
            }
            else 
            {
                // Check if the ID field is empty
                int idToRemove;
                if(!int.TryParse(removeId, out idToRemove))
                {
                    MessageBox.Show("Invalid ID format.");
                    return; // Exit if the ID format is invalid
                }

                // Convert the lecturers list to a new list to safely remove the lecturer
                List<Lecturer> lecturerList = lecturers.ToList();

                // Find the lecturer with the given ID
                Lecturer lecturerToRemove = lecturerList.FirstOrDefault(l => l.Id == idToRemove);

                // If the lecturer exists, remove them from both the lecturer list and file
                if (lecturerToRemove != null)
                {
                    // Remove the lecturer from the list
                    lecturerList.Remove(lecturerToRemove);
                    lecturers.RemoveAll(i => i.Id == idToRemove); // Remove the lecturer from the original collection

                    // Prepare the updated list of lecturer details for file saving
                    List<string> newLines = new List<string>();
                    foreach (Lecturer l in lecturerList)
                    {
                        // Format the lecturer data as a comma-separated string
                        string line = $"{l.Id}";
                        newLines.Add(line);
                    }

                    // Write the updated lecturer data back to the file
                    File.WriteAllLines("lecturers.txt", newLines);

                    // Notify the user that the lecturer has been successfully removed
                    MessageBox.Show($"Lecturer with ID: {idToRemove} has been removed.");
                    

                }
                else  // If the lecturer with the provided ID is not found, show an error message
                {
                    MessageBox.Show("Lecturer not found.");
                }

                

            }

            // Clear input fields 
            ClearInputFields();
        }
    }
}
