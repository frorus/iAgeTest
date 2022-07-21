using CommandLine;
using iAgeTest.Interface;
using iAgeTest.Models;

namespace iAgeTest.Commands
{
    /// <summary>
    /// The command to get all employees from the list.
    /// </summary>
    [Verb("-getall", HelpText = "Returns a list of all employees.")]
    public class GetAllCommand : ICommand<Employee>
    {
        /// <summary>
        /// Get all employees from the list.
        /// </summary>
        /// <param name="list">List of employees.</param>
        public void Execute(List<Employee> list)
        {
            foreach (Employee emp in list)
            {
                Console.WriteLine($"Id = {emp.Id}, " +
                                  $"FirstName = {emp.FirstName}, " +
                                  $"LastName = {emp.LastName}, " +
                                  $"SalaryPerHour = { emp.SalaryPerHour.ToString().Replace(",", ".")}");
            }
        }
    }
}