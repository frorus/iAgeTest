namespace iAgeTest.Models
{
    /// <summary>
    /// An employee.
    /// </summary>
    [Serializable]
    public class Employee
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        public decimal SalaryPerHour { get; set; }
    }
}