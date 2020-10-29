using PS.Template.Domain.DTO;

namespace PS.Template.Domain.Interfaces.Query
{
    public interface IPaqueteQuery
    {
        public ResponsePaqueteDto GetPaquete(int id);

        public bool ExistePaquete(int id);
    }
}
