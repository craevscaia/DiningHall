using System.Collections.Concurrent;
using DiningHall.Models;

namespace DiningHall.Repository.TableRepository;

public class TableRepository : ITableRepository
{
    private readonly ConcurrentBag<Table> _tables;

    public TableRepository()
    {
        _tables = new ConcurrentBag<Table>();
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

    public ConcurrentBag<Table> GetTable()
    {
        return _tables;
    }

    public Task<Table?> GetTableById(int id)
    {
        return Task.FromResult(_tables.FirstOrDefault(table => table.Id.Equals(id)));
    }

    public Task<Table?> GetFreeTable()
    {
        return Task.FromResult(_tables.FirstOrDefault(table => table.Status == Status.Free));
    }

    public Task<Table?> GetTableByStatus(Status status)
    {
        return Task.FromResult(_tables.FirstOrDefault(table => table.Status == status));
    }
}