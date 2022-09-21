using System.Collections.Concurrent;
using DiningHall.Models;

namespace DiningHall.Services.TableService;

public interface ITableService
{
    Task<Table?> GetTableById(int id);
    ConcurrentBag<Table> GetTable();
    void GenerateTables();
    Task<Table?> GetTableByStatus(Status status);
}