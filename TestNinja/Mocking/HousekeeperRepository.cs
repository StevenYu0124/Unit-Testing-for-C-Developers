namespace TestNinja.Mocking;

public class HousekeeperRepository : IHousekeeperRepository
{
    private static readonly UnitOfWork UnitOfWork = new UnitOfWork();
    public IQueryable<Housekeeper> GetQueryableHouseKeepers()
    {
        var housekeepers = UnitOfWork.Query<Housekeeper>();
        return housekeepers;
    }
}