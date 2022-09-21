using System.Collections.Concurrent;
using DiningHall.Models;
using DiningHall.Repository.TableRepository;

namespace DiningHall.Services.TableService;


public class TableService : ITableService
{
    private readonly ITableRepository _tableRepository;

    public TableService(ITableRepository tableRepository)
    {
        _tableRepository = tableRepository;
    }

    public void GenerateTables()
    {
        _tableRepository.GenerateTables();
    }
    
    public Task<Table?> GetTableByStatus(Status status)
    {
        return _tableRepository.GetTableByStatus(status);
    }

    public ConcurrentBag<Table> GetTable()
    {
        return _tableRepository.GetTable();
    }
    public Task<Table?> GetTableById(int id)
    {
        return _tableRepository.GetTableById(id);
    }
    public Task<Table?> GetFreeTable()
    {
        return _tableRepository.GetFreeTable();
    }
}