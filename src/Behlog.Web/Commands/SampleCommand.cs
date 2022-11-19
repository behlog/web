using Behlog.Core;

namespace Behlog.Web.Commands;

public class SampleCommand : IBehlogCommand<GenericResult<SampleResult>>
{
    public SampleCommand(string name)
    {
        Name = name;
    }
    
    public string Name { get; }
}


public class SampleCommandHandler : IBehlogCommandHandler<SampleCommand, GenericResult<SampleResult>>
{

    public SampleCommandHandler()
    {
    }


    public Task<GenericResult<SampleResult>> HandleAsync(
        SampleCommand message, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = new SampleResult
        {
            Result = $"The name is : {message.Name}"
        };

        var s = new GenericResult<SampleResult>
        {
            Result = result,
            IsValid = true
        };

        return Task.FromResult(s);
    }
    
}

public class GenericResult<TResult> where TResult : class
{
    
    public TResult Result { get; set; }
    
    public bool IsValid { get; set; }
} 

public class SampleResult
{
    
    public string Result { get; set; }
}