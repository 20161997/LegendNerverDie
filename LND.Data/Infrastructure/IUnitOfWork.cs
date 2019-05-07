namespace LND.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}