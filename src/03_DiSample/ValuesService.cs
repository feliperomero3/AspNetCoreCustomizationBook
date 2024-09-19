namespace DiSample;

class ValuesService : IValuesService
{
    private readonly ILogger<ValuesService> _logger;
    private readonly string[] _values = new[] { "value1", "value2" };

    public ValuesService(ILogger<ValuesService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<string> GetValues()
    {
        _logger.LogDebug("Getting values: {Values1}, {Values2}.", _values[0], _values[1]);

        return _values;
    }
}
