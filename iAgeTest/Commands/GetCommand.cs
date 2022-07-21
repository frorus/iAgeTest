using CommandLine;
using iAgeTest.Extensions;
using iAgeTest.Interface;
using iAgeTest.Models;

namespace iAgeTest.Commands
{
    /// <summary>
    /// The command to get an employee from the list.
    /// </summary>
    [Verb("-get", HelpText = "Finds an employee with Id.")]
    public class GetCommand : ICommand<Employee>
    {
        /// <summary>
        /// Gets or sets the Id of the employee.
        /// </summary>
        [Value(1, Required = true, MetaName = "Id", HelpText = "Example: Id:123")]
        public string? Id { get; set; }
        /// <summary>
        /// Get an employee from the list.
        /// </summary>
        /// <param name="list">List of employees.</param>
        /// <exception cref="Exception">Throws when the data is entered incorrectly or an employee not found.</exception>
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