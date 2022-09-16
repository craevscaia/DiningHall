using DiningHall.Models;

namespace DiningHall.Repository.TableRepository;

public class TableRepository : ITableRepository
{
    private readonly IList<Table> _tables;

    public TableRepository()
    {
        _tables = new List<Table>();
    }

    public void GenerateTables()
    {
        for (var id = 1; id <= 10; id++)
        {
            _tables.Add(new Table()
            {
                Id = id,
                Status = Status.Free
            });
        }
    }

    public IList<Table> GetTable()
    {
        return _tables;
    }

    public Table? GetTableById(int id)
    {
        return _tables.FirstOrDefault(table => table.Id.Equals(id));
    }

    public Table? GetFreeTable()
    {
        return _tables.FirstOrDefault(table => table.Status == Status.Free);
    }
}