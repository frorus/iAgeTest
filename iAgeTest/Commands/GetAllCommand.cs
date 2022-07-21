using CommandLine;
using iAgeTest.Interface;
using iAgeTest.Models;

namespace iAgeTest.Commands
{
    [Verb("-getall", HelpText = "Returns a list of all employees.")]
    public class GetAllCommand : ICommand<Employee>
    {
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