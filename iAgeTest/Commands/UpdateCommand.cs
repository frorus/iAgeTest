using CommandLine;
using iAgeTest.Extensions;
using iAgeTest.Interface;
using iAgeTest.Models;

namespace iAgeTest.Commands
{
    /// <summary>
    /// The command to update an employee from the list.
    /// </summary>
    [Verb("-update", HelpText = "Updates an employee with Id.")]
    public class UpdateCommand : ICommand<Employee>
    {
        /// <summary>
        /// Gets or sets the Id of the employee.
        /// </summary>
        [Value(1, Required = true, MetaName = "Id", HelpText = "Example: Id:123")]
        public string? Id { get; set; }
        /// <summary>
        /// Gets or sets the employee property to update.
        /// </summary>
        [Value(2, Required = true, MetaName = "PropertyToUpdate", HelpText = "You can update only one property at a time. Example: Salary:100.50")]
        public string? PropertyToUpdate { get; set; }
        /// <summary>
        /// Update the employee property from the list.
        /// </summary>
        /// <param name="list">List of employees.</param>
        /// <exception cref="Exception">Throws when the data is entered incorrectly or the employee not found.</exception>
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

                    //Subarray with property to update and value for it.
                    var subArray = PropertyToUpdate!.Split(':');

                    switch (subArray[0].ToLower())
                    {
                        case "firstname":
                            selectedEmployee.FirstName = subArray[1];
                            Console.WriteLine("The employee's first name has been updated");
                            break;
                        case "lastname":
                            selectedEmployee.LastName = subArray[1];
                            Console.WriteLine("The employee's last name has been updated");
                            break;
                        case "salary":
                            if (decimal.TryParse(subArray[1].Replace(".", ","), out decimal result))
                            {
                                selectedEmployee.SalaryPerHour = result;
                                Console.WriteLine("The employee's salary has been updated");
                            }
                            else
                            {
                                throw new Exception("Salary was entered incorrectly");
                            }
                            break;
                        default:
                            throw new Exception("Property was entered incorrectly");
                    }
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
