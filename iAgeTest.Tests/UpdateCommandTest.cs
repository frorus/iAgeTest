using FluentAssertions;
using iAgeTest.Commands;
using iAgeTest.Models;
using System.Collections.Generic;
using Xunit;

namespace iAgeTest.Tests
{
    public class UpdateCommandTest
    {
        readonly UpdateCommand commandCheckFirstName = new() { Id = "124", PropertyToUpdate = "FirstName:Dave" };
        readonly UpdateCommand commandCheckLastName = new() { Id = "124", PropertyToUpdate = "LastName:Davidson" };
        readonly UpdateCommand commandCheckSalary = new() { Id = "124", PropertyToUpdate = "Salary:101.50" };
        readonly List<Employee> list = new()
        {
            new Employee { Id = 123, FirstName = "Jane", LastName = "Doe", SalaryPerHour = 100.50m },
            new Employee { Id = 124, FirstName = "John", LastName = "Doe", SalaryPerHour = 100.50m },
        };
        readonly Employee expectedFirstName = new() { Id = 124, FirstName = "Dave", LastName = "Doe", SalaryPerHour = 100.50m };
        readonly Employee expectedLastName = new() { Id = 124, FirstName = "John", LastName = "Davidson", SalaryPerHour = 100.50m };
        readonly Employee expectedSalary = new() { Id = 124, FirstName = "John", LastName = "Doe", SalaryPerHour = 101.50m };

        [Fact]
        public void Execute_TestFirstName()
        {
            commandCheckFirstName.Execute(list);
            list.Should().ContainEquivalentOf(expectedFirstName);
        }

        [Fact]
        public void Execute_TestLastName()
        {
            commandCheckLastName.Execute(list);
            list.Should().ContainEquivalentOf(expectedLastName);
        }

        [Fact]
        public void Execute_TestSalary()
        {
            commandCheckSalary.Execute(list);
            list.Should().ContainEquivalentOf(expectedSalary);
        }
    }
}