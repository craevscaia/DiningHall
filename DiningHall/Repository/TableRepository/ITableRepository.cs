using DiningHall.Models;

namespace DiningHall.Repository.TableRepository;

public interface ITableRepository
{
    void GenerateTables();
    IList<Table> GetTable();
    Table? GetTableById(int id);
    Table? GetFreeTable();
}