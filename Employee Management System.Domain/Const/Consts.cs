using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System.Domain.Enums
{
    public enum Role
    {
        Admin = 1
    }
    public enum EmployeeSortBy
    {
        Name = 1,
        Department=2,
        Salary=3
    }
    public static class Roles
    {
        public const string Admin = "Admin";
    }
}
