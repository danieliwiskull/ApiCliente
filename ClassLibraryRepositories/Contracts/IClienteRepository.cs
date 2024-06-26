using ClassLibraryEntities;

namespace ClassLibraryRepositories.Contracts
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> ObtenerCliente(int Id);
        void InsertCliente(Cliente cli);
        void UpdateCliente(Cliente cli);
    }
}