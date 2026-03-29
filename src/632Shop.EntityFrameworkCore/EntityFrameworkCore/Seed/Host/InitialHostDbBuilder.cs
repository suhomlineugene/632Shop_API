namespace 632Shop.EntityFrameworkCore.Seed.Host;

public class InitialHostDbBuilder
{
    private readonly 632ShopDbContext _context;

    public InitialHostDbBuilder(632ShopDbContext context)
    {
        _context = context;
    }

    public void Create()
    {
        new DefaultEditionCreator(_context).Create();
        new DefaultLanguagesCreator(_context).Create();
        new HostRoleAndUserCreator(_context).Create();
        new DefaultSettingsCreator(_context).Create();

        _context.SaveChanges();
    }
}
