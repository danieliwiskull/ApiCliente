using ClassLibraryEntities;

namespace ClassLibraryServices.Contracts
{
    public interface IClienteService
    {
        IEnumerable<Cliente> ObtenerCliente(int Id);
        void InsertCliente(Cliente cli);
        void UpdateCliente(Cliente cli);
    }
}