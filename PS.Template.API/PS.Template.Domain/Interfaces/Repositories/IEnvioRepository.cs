namespace PS.Template.Domain.Interfaces.Repositories
{
    public interface IEnvioRepository
    {
        void Add<T>(T entity) where T : class;

        void SaveChanges();
    }
}
