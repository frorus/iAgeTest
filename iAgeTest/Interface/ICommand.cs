namespace iAgeTest.Interface
{
    /// <summary>
    /// Interface for commands.
    /// </summary>
    /// <typeparam name="T">The type of object to work with.</typeparam>
    public interface ICommand<T> where T : class
    {
        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="list">List of employees</param>
        void Execute(List<T> list);
    }
}