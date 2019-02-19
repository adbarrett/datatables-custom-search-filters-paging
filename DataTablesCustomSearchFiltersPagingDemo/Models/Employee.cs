using System;

namespace DataTablesCustomSearchFiltersPagingDemo.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Department Department { get; set; }
    }
}