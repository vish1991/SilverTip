namespace SilverTip.BusinessObjects
{
    public interface IUnitOfWork
    {
        void Commit();
        void CommitAsync();


    }
}
