namespace TestNinja.Mocking;

public interface IHousekeeperRepository
{
    IQueryable<Housekeeper> GetQueryableHouseKeepers();
}