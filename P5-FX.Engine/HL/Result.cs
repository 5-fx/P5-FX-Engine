namespace P5_FX.Engine.HL;

public class Result
{
    public Result()
    {
        this.State = ResultsStates.success;
        //this.ValidationResults = new ValidatorResults();
    }

    public Result(string state)
    {
        this.State = state;
        //this.ValidationResults = new ValidatorResults();
    }

    public string State { get; set; }
    public string Code { get; set; }
    public string Message { get; set; }
    //public ValidatorResults ValidationResults { get; set; }

    public Result<object> GetResult()
    {
        return new()
        {
            State = this.State,
            Message = this.Message,
           // ValidationResults = this.ValidationResults,
            Data = null,
        };
    }
}

public class Result<T> : Result
{
    public Result() : base()
    {
        this.State = ResultsStates.success;
        //this.ValidationResults = new ValidatorResults();
    }

    public Result(string state) : base(state)
    {
        this.State = state;
       // this.ValidationResults = new ValidatorResults();
    }

    public T Data { get; set; }

    public new Result GetResult()
    {
        return new()
        {
            State = this.State,
            Message = this.Message,
            //ValidationResults = this.ValidationResults,
        };
    }

}

public static class ResultCheckData<T>
{
    public static Result<IEnumerable<T>> Multiple(IEnumerable<T> dataSet)
    {
        try
        {
            if (dataSet.Any())
            {
                return new Result<IEnumerable<T>>(ResultsStates.success) { Data = dataSet.ToList() };
            }
            else
            {
                return new Result<IEnumerable<T>>(ResultsStates.empty);
            }
        }
        catch (Exception ex)
        {
            return new Result<IEnumerable<T>>(ResultsStates.error) { Message = $"Error {ex.Message}" };
        }
    }

    public static Result<T> Single(IEnumerable<T> dataSet)
    {
        try
        {
            if (dataSet.Any())
            {
                return new Result<T>(ResultsStates.success) { Data = dataSet.FirstOrDefault() };
            }
            else
            {
                return new Result<T>(ResultsStates.empty);
            }
        }
        catch (Exception ex)
        {
            return new Result<T>(ResultsStates.error) { Message = $"Error {ex.Message}" };
        }
    }
}

public class ResultsStates
{
    public const string success = "success";
    public const string unsuccess = "unsuccess";
    public const string empty = "empty";
    public const string invalid = "invalid";
    public const string error = "error";
}