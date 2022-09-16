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

    public Table? GetFreeTable()
    {
        return _tableRepository.GetFreeTable();
    }

    public IList<Table> GetTable()
    {
        return _tableRepository.GetTable();
    }
    public Table? GetTableById(int id)
    {
        return _tableRepository.GetTableById(id);
    }
}