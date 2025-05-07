using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementSystem;

namespace StudentManagementSystemTest
{
    [TestClass]
    public class CourseAssessmentMarkTest // Class for all CourseAssessmentMark methods tests
    {
        CourseAssessmentMark courseAssessmentMark = new CourseAssessmentMark(null, new List<int>() { 10, 50, 100 }); // Setup list containing numbers to test methods against

        // Get all marks method test
        [TestMethod]
        public void GetAllMarksTest() 
        {
            string expected = "10, 50, 100";
            string actual = string.Join(", ", courseAssessmentMark.GetAllMarks());
            Assert.AreEqual(expected, actual);
        }

        // Get all grades method test
        [TestMethod]
        public void GetAllGradesTest()
        {
            string expected = "E, C-, A+";
            string actual = string.Join(", ", courseAssessmentMark.GetAllGrades());
            Assert.AreEqual(expected, actual);
        }

        // Get highest mark method test
        [TestMethod]
        public void GetHighestMarksTest()
        {
            string expected = "100";
            string actual = string.Join(", ", courseAssessmentMark.GetHighestMarks());
            Assert.AreEqual(expected, actual);
        }

        // Get lowest passing mark method test
        [TestMethod]
        public void GetLowestMarksTest()
        {
            string expected = "50";
            string actual = string.Join(", ", courseAssessmentMark.GetLowestMarks());
            Assert.AreEqual(expected, actual);
        }

        // Get fail mark method test
        [TestMethod]
        public void GetFailMarks()
        {
            string expected = "10";
            string actual = string.Join(", ", courseAssessmentMark.GetFailMarks());
            Assert.AreEqual(expected, actual);
        }

        // Get average mark test
        [TestMethod]
        public void GetAverageMarksTest()
        {
            string expected = "53.3333333333333";
            string actual = string.Join(", ", courseAssessmentMark.GetAverageMarks());
            Assert.AreEqual(expected, actual);
        }

        // Get average grade method test
        [TestMethod]
        public void GetAverageGradeTest()
        {
            string expected = "C-";
            string actual = string.Join(", ", courseAssessmentMark.GetAverageGrade());
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class InstitutionTest // Create class for testing of Institution class
    {
        Institution institution = new Institution("Otago Polytechnic", "Otago", "New Zealand"); // Setup containing Institution Name, Region, Country

        // Test Institution name
        [TestMethod]
        public void InstitutionNameTest()
        {
            string expected = "Otago Polytechnic";
            string actual = institution.Name;
            Assert.AreEqual(expected, actual);
        }

        // Test Institution country
        [TestMethod]
        public void InstitutionRegionTest()
        {
            string expected = "Otago";
            string actual = institution.Region;
            Assert.AreEqual(expected, actual);
        }

        // Test Institution country
        [TestMethod]
        public void InstitutionCountryTest()
        {
            string expected = "New Zealand";
            string actual = institution.Country;
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class PersonTest // Setup class to test Person class
    {
        Person person = new Person(1, "Cherrington", "Ngatai"); // Setup list containing Person ID, LastName, FirstName

        // Person ID test
        [TestMethod]
        public void PersonIDTest()
        {
            int expected = 1;
            int actual = person.Id;
            Assert.AreEqual(expected, actual);          
        }

        // Person Last name test
        [TestMethod]
        public void PersonLastNameTest()
        {
            string expected = "Cherrington";
            string actual = person.LastName;
            Assert.AreEqual(expected, actual);
        }

        // Person First name test
        [TestMethod]
        public void PersonFirstNameTest()
        {
            string expected = "Ngatai";
            string actual = person.FirstName;
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class SeedingTest 
    {
        private List<Institution> institutions;
        private List<Department> departments;
        private List<Course> courses;

        [TestInitialize]
        public void InitializeList()
        {
            // Reseed the lists after clearing
            institutions = Utils.SeedInstitutions();
            departments = Utils.SeedDepartments();
            courses = Utils.SeedCourses();
        }

        [TestCleanup]
        public void CleanupSeedLists()
        {
            institutions.Clear();
            departments.Clear();
            courses.Clear();
        }

        [TestMethod]
        public void SeedInstitutionTest()
        {
            int expectedCount = 3;
            Assert.AreEqual(expectedCount, institutions.Count);
        }
        [TestMethod]
        public void SeedDepartmentTest()
        {
            int expectedCount = 3;
            Assert.AreEqual(expectedCount, departments.Count);
        }
        [TestMethod]
        public void SeedCourseTest()
        {
            int expectedCount = 3;
            Assert.AreEqual(expectedCount, courses.Count);
        }
    }

    [TestClass]
    public class StaffSalaryTest
    {
        Institution institution = new Institution("Otago Polytechnic", "Otago", "New Zealand");

        [TestMethod]
        public void LecturerSalaryTest()
        {
            var department = new Department(institution, "Test Department");
            var course = new Course(department, "TEST101", "Test Name", "Test Describe", 1, 500);

            Lecturer lecturer = new Lecturer(1, "Test Name", "Test Name", Lecturer.EPosition.LECTURER, Lecturer.ESalary.LECTURER, course);

            int expected = 85000;
            Assert.AreEqual(expected, (int)lecturer.Salary);
        }
        
        [TestMethod]
        public void SeniorLecturerSalaryTest()
        {
            var department = new Department(institution, "Test Department");
            var course = new Course(department, "TEST101", "Test Name", "Test Describe", 1, 500);

            Lecturer lecturer = new Lecturer(1, "Test Name", "Test Name", Lecturer.EPosition.SENIOR_LECTURER, Lecturer.ESalary.SENIOR_LECTURER, course);

            int expected = 100000;
            Assert.AreEqual(expected, (int)lecturer.Salary);
        }
        [TestMethod]
        public void PrincipalLecturerSalaryTest()
        {
            var department = new Department(institution, "Test Department");
            var course = new Course(department, "TEST101", "Test Name", "Test Describe", 1, 500);

            Lecturer lecturer = new Lecturer(1, "Test Name", "Test Name", Lecturer.EPosition.PRINCIPAL_LECTURER, Lecturer.ESalary.PRINCIPAL_LECTURER, course);

            int expected = 115000;
            Assert.AreEqual(expected, (int)lecturer.Salary);
        }
        [TestMethod]
        public void AssocLecturerSalaryTest()
        {
            var department = new Department(institution, "Test Department");
            var course = new Course(department, "TEST101", "Test Name", "Test Describe", 1, 500);

            Lecturer lecturer = new Lecturer(1, "Test Name", "Test Name", Lecturer.EPosition.ASSOCIATE_PROFESSOR, Lecturer.ESalary.ASSOCIATE_PROFESSOR, course);

            int expected = 130000;
            Assert.AreEqual(expected, (int)lecturer.Salary);
        }
        
    }
}

