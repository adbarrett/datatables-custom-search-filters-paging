using System;
using System.Collections.Generic;

namespace DataTablesCustomSearchFiltersPagingDemo.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Department Department { get; set; }

        public static List<Employee> GetSampleEmployees()
        {
            List<Department> departments = Department.GetSampleDepartments();

            return new List<Employee>
            {
                new Employee { Id = "9f673aa0-8b58-46ef-b246-6ea717578d69", FirstName = "Greta", LastName = "Beaton", DateOfBirth = new DateTime(1976, 3, 31), Department = departments[1] },
                new Employee { Id = "c31d10af-a3dd-423d-9f07-1ef10f6964a7", FirstName = "Ashlin", LastName = "Pigford", DateOfBirth = new DateTime(1973, 5, 19), Department = departments[1] },
                new Employee { Id = "266e3804-ec1d-4b98-bd81-d202c56e5e60", FirstName = "Latisha", LastName = "Cantera", DateOfBirth = new DateTime(1966, 5, 10), Department = departments[3] },
                new Employee { Id = "957dae5c-e9c5-42a3-b544-c1d2c29c7d4c", FirstName = "Rori", LastName = "Le land", DateOfBirth = new DateTime(1991, 7, 9), Department = departments[1] },
                new Employee { Id = "5a2db5dc-74ab-4ae0-8eb6-c5d7d813a73a", FirstName = "Jeanie", LastName = "Gregoli", DateOfBirth = new DateTime(1986, 1, 13), Department = departments[2] },
                new Employee { Id = "b5794729-f225-46f9-a405-f953b51ad00a", FirstName = "Shawn", LastName = "McGlaud", DateOfBirth = new DateTime(1988, 8, 8), Department = departments[0] },
                new Employee { Id = "9b70cbf9-237e-4f2c-9229-293bff521a07", FirstName = "Caleb", LastName = "Ramard", DateOfBirth = new DateTime(1980, 2, 14), Department = departments[3] },
                new Employee { Id = "ff9c8a8a-01b0-420b-8196-53536274a44e", FirstName = "Chrysler", LastName = "Goodlet", DateOfBirth = new DateTime(1978, 8, 28), Department = departments[3] },
                new Employee { Id = "a606dd25-6f2d-4838-ae00-1b7d328f62bd", FirstName = "Danita", LastName = "Fetherston", DateOfBirth = new DateTime(1973, 1, 21), Department = departments[0] },
                new Employee { Id = "d2733c20-88ec-4167-b09c-c5f30855dcd9", FirstName = "Sarah", LastName = "Gaynor", DateOfBirth = new DateTime(1983, 9, 16), Department = departments[0] },
                new Employee { Id = "71de7087-3f2d-49e3-ac72-aacae6db5d36", FirstName = "Dore", LastName = "Sturgis", DateOfBirth = new DateTime(1969, 12, 5), Department = departments[0] },
                new Employee { Id = "5e46f4b1-862a-4787-a5b6-b333e2a4416b", FirstName = "Cathyleen", LastName = "Dosdale", DateOfBirth = new DateTime(1981, 8, 11), Department = departments[1] },
                new Employee { Id = "2f4868cc-0ea5-43eb-9e9a-740fa39036e7", FirstName = "Ruperta", LastName = "Jorry", DateOfBirth = new DateTime(1999, 7, 16), Department = departments[2] },
                new Employee { Id = "721f0c3c-c492-41a0-bbe2-88da12d05563", FirstName = "Colman", LastName = "Fishlee", DateOfBirth = new DateTime(1982, 5, 27), Department = departments[1] },
                new Employee { Id = "4d6d0353-62c7-4d00-9c56-b0de152abb38", FirstName = "Adlai", LastName = "Rasell", DateOfBirth = new DateTime(1978, 10, 9), Department = departments[0] },
                new Employee { Id = "22850131-cbe7-49bb-ab0d-82bc3109e562", FirstName = "Adolphus", LastName = "Lamboll", DateOfBirth = new DateTime(1965, 1, 3), Department = departments[3] },
                new Employee { Id = "a09ec377-fed0-44e5-9b2a-3f83e2c39963", FirstName = "Milly", LastName = "Fairbridge", DateOfBirth = new DateTime(1968, 1, 25), Department = departments[0] },
                new Employee { Id = "6983564b-72d6-4aad-9536-36c25f7365a9", FirstName = "Wyndham", LastName = "Creeber", DateOfBirth = new DateTime(1979, 6, 11), Department = departments[3] },
                new Employee { Id = "fa33b926-d913-4b7d-9bab-63f6736d4b47", FirstName = "Shep", LastName = "Odger", DateOfBirth = new DateTime(1995, 7, 31), Department = departments[0] },
                new Employee { Id = "4ec2fa72-b55e-45a6-9ac8-5935178a981f", FirstName = "Roldan", LastName = "Kording", DateOfBirth = new DateTime(1985, 7, 20), Department = departments[1] }
            };
        }
    }
}