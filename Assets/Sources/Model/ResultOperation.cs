namespace Sources.Model
{
    public class ResultOperation
    {
        public string Expression { get; }
        
        public int Result { get; }
        
        public bool Success { get; }

        public ResultOperation(string expression, bool success, int result = 0)
        {
            Expression = expression;
            Success = success;
            Result = result;
        }
    }
}