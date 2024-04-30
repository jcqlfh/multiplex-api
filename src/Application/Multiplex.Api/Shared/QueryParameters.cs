namespace Multiplex.Api.Shared;

public class QueryParameters<T>
{
    public T? Model { get; set; }
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
}