using CommandLine;
using iAgeTest.Extensions;
using iAgeTest.Interface;
using iAgeTest.Models;

namespace iAgeTest.Commands
{
    [Verb("-add", HelpText = "Adds a new employee to the file.")]
    public class AddCommand : ICommand<Employee>
    {
        [Value(1, Required = true, MetaName = "FirstName", HelpText = "Example: FirstName:John")]
        public string? FirstName { get; set; }
        [Value(2, Required = true, MetaName = "LastName", HelpText = "Example: LastName:Doe")]
        public string? LastName { get; set; }
        [Value(3, Required = true, MetaName = "Salary", HelpText = "Example: Salary:100.50")]
        public string? Salary { get; set; }
        public void Execute(List<Employee> list)
        {
            try
            {
                int id = list.Max(e => e.Id) + 1;
                var firstName = ParametersParser.SplitString(FirstName!);
                var lastName = ParametersParser.SplitString(LastName!);
                var salary = ParametersParser.SplitString(Salary!).Replace(".", ",");

                if (firstName.Any(Char.IsDigit) || lastName.Any(Char.IsDigit))
                {
                    throw new Exception("FirstName or LastName contains digits");
                }

                if (decimal.TryParse(salary, out decimal result))
                {
                    list.Add(new Employee { Id = id, FirstName = firstName, LastName = lastName, SalaryPerHour = result });
                    Console.WriteLine($"An employee with ID:{id} has been created");
                }
                else
                {
                    throw new Exception("Salary was entered incorrectly");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
