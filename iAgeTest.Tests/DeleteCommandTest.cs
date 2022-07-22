using FluentAssertions;
using iAgeTest.Commands;
using iAgeTest.Models;
using System.Collections.Generic;
using Xunit;

namespace iAgeTest.Tests
{
    public class DeleteCommandTest
    {
        readonly DeleteCommand command = new() { Id = "124" };
        readonly List<Employee> list = new()
        {
            new Employee { Id = 123, FirstName = "Jane", LastName = "Doe", SalaryPerHour = 100.50m },
            new Employee { Id = 124, FirstName = "John", LastName = "Doe", SalaryPerHour = 100.50m },
        };
        readonly List<Employee> expectedList = new() { new Employee { Id = 123, FirstName = "Jane", LastName = "Doe", SalaryPerHour = 100.50m } };

        [Fact]
        public void ExecuteTest()
        {
            command.Execute(list);
            list.Should().BeEquivalentTo(expectedList);
        }
    }
}