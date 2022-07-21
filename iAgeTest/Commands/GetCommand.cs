using CommandLine;
using iAgeTest.Extensions;
using iAgeTest.Interface;
using iAgeTest.Models;

namespace iAgeTest.Commands
{
    [Verb("-get", HelpText = "Finds an employee with Id.")]
    public class GetCommand : ICommand<Employee>
    {
        [Value(1, Required = true, MetaName = "Id", HelpText = "Example: Id:123")]
        public string? Id { get; set; }
        public void Execute(List<Employee> list)
        {
            try
            {
                if (Int32.TryParse(ParametersParser.SplitString(Id!), out int id))
                {
                    var selectedEmployee = list.Where(x => x.Id.Equals(id)).FirstOrDefault();

                    if (selectedEmployee == null)
                    {
                        throw new Exception($"Employee with Id:{id} not found");
                    }

                    Console.WriteLine($"Id = {selectedEmployee!.Id}, " +
                                      $"FirstName = {selectedEmployee.FirstName}, " +
                                      $"LastName = {selectedEmployee.LastName}, " +
                                      $"SalaryPerHour = { selectedEmployee.SalaryPerHour.ToString().Replace(",", ".")}");
                }
                else
                {
                    throw new Exception("Id was entered incorrectly");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}