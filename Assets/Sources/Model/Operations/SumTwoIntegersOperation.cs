using System.Linq;
using System.Text.RegularExpressions;
using Sources.Model;

public class SumTwoIntegersOperation : IOperation
{
    private static readonly Regex ValidExpressionRegex = new(@"^(?:\d+\+)*\d+$", RegexOptions.Compiled);
    
    public bool IsValidInput(string input) => ValidExpressionRegex.IsMatch(input);

    public ResultOperation Execute(string expression)
    {
        int[] values = expression.Split('+').Select(int.Parse).ToArray();

        return new ResultOperation(expression, true, values.Sum());
    }
}