namespace WebApplication1.models;

public class DataContext
{
    public int RowCount { get;} = Random.Shared.Next(1, 1_000_000_000);
}