namespace LND.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private LegendNeverDieDbContext dbContext;

        public LegendNeverDieDbContext Init()
        {
            return dbContext ?? (dbContext = new LegendNeverDieDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}