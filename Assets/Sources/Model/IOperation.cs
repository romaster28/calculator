namespace Sources.Model
{
    public interface IOperation
    {
        bool IsValidInput(string input);

        ResultOperation Execute(string expression);
    }
}