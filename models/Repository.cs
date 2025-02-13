namespace WebApplication1.models;

public class Repository
{
    private readonly DataContext _dataContext;

    public Repository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public int getRowCount => _dataContext.RowCount;
}