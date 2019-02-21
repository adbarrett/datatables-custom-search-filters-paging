using System;
using System.Collections.Generic;

namespace DataTablesCustomSearchFiltersPagingDemo.Models
{
    public class Department
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public static List<Department> GetSampleDepartments()
        {
            return new List<Department>
            {
                new Department { Id = Guid.NewGuid().ToString(), Name = "Finance" },
                new Department { Id = Guid.NewGuid().ToString(), Name = "Sales" },
                new Department { Id = Guid.NewGuid().ToString(), Name = "HR" },
                new Department { Id = Guid.NewGuid().ToString(), Name = "IT" }
            };
        }
    }
}