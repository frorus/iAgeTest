using CommandLine;
using iAgeTest.Extensions;
using iAgeTest.Interface;
using iAgeTest.Models;

namespace iAgeTest.Commands
{
    /// <summary>
    /// The command to delete an employee from the list.
    /// </summary>
    [Verb("-delete", HelpText = "Deletes an employee with Id.")]
    public class DeleteCommand : ICommand<Employee>
    {
        /// <summary>
        /// Gets or sets the Id of the employee.
        /// </summary>
        [Value(1, Required = true, MetaName = "Id", HelpText = "Example: Id:123")]
        public string? Id { get; set; }
        /// <summary>
        /// Delete an employee from the list.
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

                    list.Remove(selectedEmployee);

                    Console.WriteLine($"An employee with ID:{id} has been deleted");
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
