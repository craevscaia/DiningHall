using System.Collections.Concurrent;
using DiningHall.Models;

namespace DiningHall.Repository.TableRepository;

public interface ITableRepository
{
    void GenerateTables();
    ConcurrentBag<Table> GetTable();
    Task<Table?> GetTableById(int id);
    Task<Table?> GetTableByStatus(Status status);
    Task<Table?> GetFreeTable();
}