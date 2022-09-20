using DiningHall.Models;

namespace DiningHall.Services.TableService;

public interface ITableService
{
    Table? GetTableById(int id);
    IList<Table> GetTable();
    void GenerateTables();
    Table? GetTableByStatus(Status status);
}