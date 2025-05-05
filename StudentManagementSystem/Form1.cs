using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private int nextLearnerId = 1;
        

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
                mark1TextBox.Visible = false;
                mark2TextBox.Visible = false;
                mark3TextBox.Visible = false;
                mark4TextBox.Visible = false;
                mark5TextBox.Visible = false;
                saveButton.Visible = false;

                label2.Visible = false; // First Name label
                label3.Visible = false; // Last Name label
                label4.Visible = false; // Course label
                label5.Visible = false; // Mark 1 label
                label6.Visible = false; // Mark 2 label
                label7.Visible = false; // Mark 3 label
                label8.Visible = false; // Mark 4 label
                label9.Visible = false; // Mark 5 label
            }
            else
            {
                dataGridView1.Visible = false;

                firstNameTextBox.Visible = true;
                lastNameTextBox.Visible = true;
                courseComboBox.Visible = true;
                positionComboBox.Visible = false;
                salaryTextBox.Visible = false;
                mark1TextBox.Visible = true;
                mark2TextBox.Visible = true;
                mark3TextBox.Visible = true;
                mark4TextBox.Visible = true;
                mark5TextBox.Visible = true;
                saveButton.Visible = true;
                saveLecturerBtn.Visible = false;

                label2.Visible = true; // First Name label
                label3.Visible = true; // Last Name label
                label4.Visible = true; // Course label
                label5.Visible = true; // Mark 1 label
                label6.Visible = true; // Mark 2 label
                label7.Visible = true; // Mark 3 label
                label8.Visible = true; // Mark 4 label
                label9.Visible = true; // Mark 5 label
                label10.Visible = false; // Position label
                label11.Visible = false; // Salary label
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
                salaryTextBox.Visible = true;
                mark1TextBox.Visible = false;
                mark2TextBox.Visible = false;
                mark3TextBox.Visible = false;
                mark4TextBox.Visible = false;
                mark5TextBox.Visible = false;
                saveLecturerBtn.Visible = true;
                saveButton.Visible = false;

                label2.Visible = true; // First Name label
                label3.Visible = true; // Last Name label
                label4.Visible = true; // Course label
                label5.Visible = false; // Mark 1 label
                label6.Visible = false; // Mark 2 label
                label7.Visible = false; // Mark 3 label
                label8.Visible = false; // Mark 4 label
                label9.Visible = false; // Mark 5 label
                label10.Visible = true; // Position label
                label11.Visible = true; // Salary label
            }
        }

        private void ClearInputFields()
        {
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            courseComboBox.Text = "";
            mark1TextBox.Text = "";
            mark2TextBox.Text = "";
            mark3TextBox.Text = "";
            mark4TextBox.Text = "";
            mark5TextBox.Text = "";
        }

        private void DisplayCourseDetail_btn(object sender, EventArgs e)
        {
            courses = Utils.SeedCourses();
            //make the column headings
            DataTable courseDataTable = new DataTable();
            courseDataTable.Columns.Clear();
            courseDataTable.Columns.Add("Course");
            courseDataTable.Columns.Add("Description");
            courseDataTable.Columns.Add("Credits");
            courseDataTable.Columns.Add("Fees");


            //make the column rows
            foreach (Course course in courses)
            {
                var row = courseDataTable.NewRow();
                row["Course"] = course.DisplayCodeName();
                row["Description"] = course.Description;
                row["Credits"] = course.Credits;
                row["Fees"] = course.Fees;

                courseDataTable.Rows.Add(row);
            }

            dataGridView1.DataSource = courseDataTable;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
        }

        private void DisplayAllMarks_btn(object sender, EventArgs e)
        {        
            DataTable learnerDataTable = new DataTable();
            learnerDataTable.Clear();
            learnerDataTable.Columns.Add("ID");
            learnerDataTable.Columns.Add("Name"); 
            learnerDataTable.Columns.Add("Mark 1");
            learnerDataTable.Columns.Add("Mark 2");
            learnerDataTable.Columns.Add("Mark 3");
            learnerDataTable.Columns.Add("Mark 4");
            learnerDataTable.Columns.Add("Mark 5");

            foreach (var learner in learners)
            {
                List<int> marks = new List<int>(learner.CourseAssessmentMarks.GetAllMarks());
                string name = $"{learner.FirstName} {learner.LastName}";
                var row = learnerDataTable.NewRow();
                row["ID"] = learner.Id;
                row["Name"] = name;
                for (int i = 0; i < 5; i++)
                {
                    row[$"Mark {i + 1}"] = marks.Count > i ? marks[i] : 0;
                }
                learnerDataTable.Rows.Add(row);
            }

            dataGridView1.DataSource = learnerDataTable;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            ToggleControls(true);
        }

        private void DisplayAllGrades_btn(object sender, EventArgs e)
        {            
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

            foreach (var learner in learners)
            {
                List<string> marks = new List<string>(learner.CourseAssessmentMarks.GetAllGrades());

                string name = $"{learner.FirstName} {learner.LastName}";
                var row = gradeDataTable.NewRow();
                row["ID"] = learner.Id;
                row["Name"] = name;
                row["Code"] = learner.CourseAssessmentMarks.Course.DisplayCodeName();                
                for (int i = 0; i < 5; i++)
                {                  
                    row[$"Grade {i + 1}"] = marks.Count > i ? marks[i] : "N/A";
                }
                gradeDataTable.Rows.Add(row);
            }
            
            
            
            dataGridView1.DataSource = gradeDataTable;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            ToggleControls(true);

        }

        private void DisplayHighestMarks_btn(object sender, EventArgs e)
        {
            DataTable highestMarkTable = new DataTable();

            highestMarkTable.Columns.Clear();
            highestMarkTable.Columns.Add("ID");
            highestMarkTable.Columns.Add("Name");
            highestMarkTable.Columns.Add("Course");
            highestMarkTable.Columns.Add("Highest Mark");

            foreach (var learner in learners)
            {
                List<int> marks = new List<int>(learner.CourseAssessmentMarks.GetHighestMarks());
                string name = $"{learner.FirstName} {learner.LastName}";
                var row = highestMarkTable.NewRow();
                row["ID"] = learner.Id;
                row["Name"] = name;
                row["Course"] = learner.CourseAssessmentMarks.Course.DisplayCodeName();
                row["Highest Mark"] = string.Join(", ", marks);
                highestMarkTable.Rows.Add(row);
            }

            dataGridView1.DataSource = highestMarkTable;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            ToggleControls(true);
        }

        private void DisplayLowestMarks_btn(object sender, EventArgs e)
        {
            DataTable lowestMarkTable = new DataTable();

            lowestMarkTable.Columns.Clear();
            lowestMarkTable.Columns.Add("ID");
            lowestMarkTable.Columns.Add("Name");
            lowestMarkTable.Columns.Add("Code");
            lowestMarkTable.Columns.Add("Lowest Mark");

            foreach (var  learner in learners)
            {
                List<int> marks = new List<int>(learner.CourseAssessmentMarks.GetLowestMarks());
                string name = $"{learner.FirstName} {learner.LastName}";
                var row = lowestMarkTable.NewRow();
                row["ID"] = learner.Id;
                row["Name"] = name;
                row["Code"] = learner.CourseAssessmentMarks.Course.DisplayCodeName();
                if (!marks.Any(mark => mark <= 50))
                {
                    row["Lowest Mark"] = "N/A";
                }
                else
                {
                    row["Lowest Mark"] = string.Join(", ", marks); 
                }

                lowestMarkTable.Rows.Add(row);
            }

            dataGridView1.DataSource = lowestMarkTable;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            ToggleControls(true);
        }
        

        private void DisplayFailMarks_btn(object sender, EventArgs e)
        {
            DataTable failMarkTable = new DataTable();

            failMarkTable.Columns.Clear();
            failMarkTable.Columns.Add("ID");
            failMarkTable.Columns.Add("Name");
            failMarkTable.Columns.Add("Code");
            failMarkTable.Columns.Add("Fail Mark");

            foreach (var learner in learners)
            {
                List<int> marks = new List<int>(learner.CourseAssessmentMarks.GetFailMarks());
                string name = $"{learner.FirstName} {learner.LastName}";
                var row = failMarkTable.NewRow();
                row["ID"] = learner.Id;
                row["Name"] = name;
                row["Code"] = learner.CourseAssessmentMarks.Course.DisplayCodeName();
                if (!marks.Any(mark => mark <= 50))
                {
                    row["Fail Mark"] = "N/A";
                }
                else
                {
                    row["Fail Mark"] = string.Join(", ", marks);

                }


                failMarkTable.Rows.Add(row);
            }

            dataGridView1.DataSource = failMarkTable;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            ToggleControls(true);
        }

        private void DisplayAvgMarks_btn(object sender, EventArgs e)
        {
            DataTable avgMarkTable = new DataTable();

            avgMarkTable.Columns.Clear();
            avgMarkTable.Columns.Add("ID");
            avgMarkTable.Columns.Add("Name");
            avgMarkTable.Columns.Add("Code");
            avgMarkTable.Columns.Add("Average Mark");

            foreach(var learner in learners)
            {
                double avgMark = learner.CourseAssessmentMarks.GetAverageMarks();
                string name = $"{learner.FirstName} {learner.LastName}";
                var row = avgMarkTable.NewRow();
                row["ID"] = learner.Id;
                row["Name"] = name;
                row["Code"] = learner.CourseAssessmentMarks.Course.DisplayCodeName();
                row["Average Mark"] = avgMark;
                
                avgMarkTable.Rows.Add(row);
            }

            dataGridView1.DataSource = avgMarkTable;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            ToggleControls(true);
        }

        private void DisplayAvgGrades_btn(object sender, EventArgs e)
        {
            DataTable avgGradeTable = new DataTable();

            avgGradeTable.Columns.Clear();
            avgGradeTable.Columns.Add("ID");
            avgGradeTable.Columns.Add("Name");
            avgGradeTable.Columns.Add("Code");
            avgGradeTable.Columns.Add("Average Grade");

            foreach(var learner in learners)
            {
                string avgGrade = learner.CourseAssessmentMarks.GetAverageGrade();
                string name = $"{learner.FirstName} {learner.LastName}";
                var row = avgGradeTable.NewRow();
                row["ID"] = learner.Id;
                row["Name"] = name;
                row["Code"] = learner.CourseAssessmentMarks.Course.DisplayCodeName();
                row["Average Grade"] = avgGrade;

                avgGradeTable.Rows.Add(row);
            }

            dataGridView1.DataSource = avgGradeTable;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            ToggleControls(true);
        }

        private void DisplayLecturerDetails_btn(object sender, EventArgs e)
        {
            DataTable lecturerDetailTable = new DataTable();

            lecturerDetailTable.Columns.Clear();
            lecturerDetailTable.Columns.Add("ID");
            lecturerDetailTable.Columns.Add("Name");
            lecturerDetailTable.Columns.Add("Position");
            lecturerDetailTable.Columns.Add("Institution");
            lecturerDetailTable.Columns.Add("Department");
            lecturerDetailTable.Columns.Add("Course");
            lecturerDetailTable.Columns.Add("Salary");

            if (lecturers == null || lecturers.Count == 0)
            {
                MessageBox.Show("No lecturers found!", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                foreach (var lecturer in lecturers)
                {
                    string institutionDetails = lecturer.Course.Department.Institution.DisplayInfo();
                    string name = $"{lecturer.FirstName} {lecturer.LastName}";
                    var row = lecturerDetailTable.NewRow();
                    row["ID"] = lecturer.DisplayPersonId();
                    row["Name"] = name;
                    row["Position"] = lecturer.Position.ToString();
                    row["Institution"] = institutionDetails;
                    row["Department"] = lecturer.Course.Department.Name;
                    row["Course"] = lecturer.Course.DisplayCodeName();
                    row["Salary"] = (int)lecturer.Salary; 

                    lecturerDetailTable.Rows.Add(row);
                }

                dataGridView1.DataSource = lecturerDetailTable;
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
                ToggleControls(true);
            }

            

        }

        private void AddLearner_btn(object sender, EventArgs e)
        {
            ToggleControls(false);
        }

        private void AddLecturer_btn(object sender, EventArgs e)
        {
           ToggleLecturerControls(false);
        }

        private void RemoveLecturer_btn(object sender, EventArgs e)
        {

        }
        private void Exit_btn(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
            StreamWriter sw;
            string details = "";
            string filePath = "learners.txt";
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            int selectedIndex = courseComboBox.SelectedIndex;
            string[] assessmentMarks = new string[5];
            assessmentMarks[0] = mark1TextBox.Text;
            assessmentMarks[1] = mark2TextBox.Text;
            assessmentMarks[2] = mark3TextBox.Text;
            assessmentMarks[3] = mark4TextBox.Text;
            assessmentMarks[4] = mark5TextBox.Text;


            if (firstNameTextBox.Text.Trim() == "" || lastNameTextBox.Text.Trim() == "" || courseComboBox.SelectedIndex == -1 || mark1TextBox.Text.Trim() == "" || mark2TextBox.Text.Trim() == "" || mark3TextBox.Text.Trim() == "" || mark4TextBox.Text.Trim() == "" || mark5TextBox.Text.Trim() == "")
            {
                MessageBox.Show("Error, Please fill in all elements");
            }
            else
            {
                if ((int.Parse(mark1TextBox.Text) <= 0 || int.Parse(mark1TextBox.Text) > 100) || (int.Parse(mark2TextBox.Text) <= 0 || int.Parse(mark2TextBox.Text) > 100) || (int.Parse(mark3TextBox.Text) <= 0 || int.Parse(mark3TextBox.Text) > 100) || (int.Parse(mark4TextBox.Text) <= 0 || int.Parse(mark4TextBox.Text) > 100) || (int.Parse(mark5TextBox.Text) <= 0 || int.Parse(mark5TextBox.Text) > 100))
                {
                    MessageBox.Show("Invalid, Please enter a number between 1-100");
                }

                else
                {
                    int newLearnerId = (learners != null && learners.Any()) ? learners.Max(x => x.Id) + 1 : 1;

                    details = newLearnerId + "," + firstName + "," + lastName + "," + selectedIndex + "," + assessmentMarks[0] + "," + assessmentMarks[1] + "," + assessmentMarks[2] + "," + assessmentMarks[3] + "," + assessmentMarks[4];                   
                    sw = new StreamWriter(filePath, append: true);
                    sw.WriteLine(details);
                    sw.Close();
                    
                    List<int> marks = new List<int>()
                    {
                        Convert.ToInt32(assessmentMarks[0]),
                        Convert.ToInt32(assessmentMarks[1]),
                        Convert.ToInt32(assessmentMarks[2]),
                        Convert.ToInt32(assessmentMarks[3]),
                        Convert.ToInt32(assessmentMarks[4]),
                    };
                    Learner newLearner = new Learner(newLearnerId, firstName, lastName, new CourseAssessmentMark(courses[selectedIndex], marks));

                    learners.Add(newLearner);
                }
            }

            
            MessageBox.Show("New Learner Added!");
            ClearInputFields();
        }

        private void saveLecturerBtn_Click(object sender, EventArgs e)
        {
            StreamWriter sw;
            string details = "";
            string filePath = "lecturers.txt";
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string specialCharacters = "! @ # $ % ^ & * ( )";
            EPosition selectedPosition = (EPosition)positionComboBox.SelectedItem;
            ESalary salary = (ESalary)Enum.Parse(typeof(ESalary), selectedPosition.ToString());
            salaryTextBox.Text = salary.ToString();
            Course selectedCourseIndex = (Course)courseComboBox.SelectedItem;

            if (firstNameTextBox.Text.Trim() == "" || lastNameTextBox.Text.Trim() == "" || courseComboBox.SelectedIndex == -1 || positionComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all elements in!");
            }
            else
            {
                if (firstName.Any(c => specialCharacters.Contains(c)) || lastName.Any(c => specialCharacters.Contains(c)))
                {
                    MessageBox.Show("You can not use special Characters");
                    return;
                }

                else
                {
                    int newLecturerId = (lecturers != null && lecturers.Any()) ? lecturers.Max(x => x.Id) + 1 : 1;

                    details = newLecturerId + "," + firstName + "," + lastName + "," + selectedCourseIndex + "," + selectedPosition + "," + salary;
                    sw = new StreamWriter(filePath, append: true);
                    sw.WriteLine(details);
                    sw.Close();

                    Lecturer newLecturer = new Lecturer(newLecturerId, firstName, lastName, selectedPosition, salary, selectedCourseIndex);
                    lecturers.Add(newLecturer);

                }
            }

            MessageBox.Show("New Lecturer Added!");
            ClearInputFields();
        }
    }
}
