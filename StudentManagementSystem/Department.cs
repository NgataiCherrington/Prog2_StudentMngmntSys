using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class Department
    {
        private Institution institution;
        private string name;
        public Department(Institution institution, string name)
        {
            this.institution = institution;
            this.name = name;
        }

        public Institution Institution { get => institution; set => institution = value; }
        public string Name { get => name; set => name = value; }

        public string DisplayInfo() => $"Institution:\t{institution.Name}\nDepartment:\t{name}";
    }
}
