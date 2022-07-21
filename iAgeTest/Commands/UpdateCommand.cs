using CommandLine;
using iAgeTest.Extensions;
using iAgeTest.Interface;
using iAgeTest.Models;

namespace iAgeTest.Commands
{
    [Verb("-update", HelpText = "Updates an employee with Id.")]
    public class UpdateCommand : ICommand<Employee>
    {
        [Value(1, Required = true, MetaName = "Id", HelpText = "Example: Id:123")]
        public string? Id { get; set; }
        [Value(2, Required = true, MetaName = "PropertyToUpdate", HelpText = "You can update only one property at a time. Example: Salary:100.50")]
        public string? PropertyToUpdate { get; set; }
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
