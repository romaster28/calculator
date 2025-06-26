using System;
using Sources.Model;

public class Calculator
{
    private readonly IOperation[] _available;

    public Calculator(IOperation[] available)
    {
        _available = available ?? throw new ArgumentNullException(nameof(available));
    }

    public ResultOperation Execute(string expression)
    {
        foreach (var operation in _available)
        {
            if (operation.IsValidInput(expression))
                return operation.Execute(expression);
        }

        return new ResultOperation(expression, false);
    }
}