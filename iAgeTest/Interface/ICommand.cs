namespace iAgeTest.Interface
{
    public interface ICommand<T> where T : class
    {
        void Execute(List<T> list);
    }
}