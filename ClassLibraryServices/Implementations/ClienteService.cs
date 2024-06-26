using ClassLibraryServices.Contracts;
using ClassLibraryRepositories.Contracts;
using ClassLibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryServices.Implementations
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _ClienteRepository;

        public ClienteService(IClienteRepository ClienteRepository)
        {
            _ClienteRepository = ClienteRepository ?? throw new ArgumentNullException(nameof(ClienteRepository));
        }

        public IEnumerable<Cliente> ObtenerCliente(int Id)
        {
            return _ClienteRepository.ObtenerCliente(Id);
        }

        public void InsertCliente(Cliente cli)
        {
            _ClienteRepository.InsertCliente(cli);
        }

        public void UpdateCliente(Cliente cli)
        {
            _ClienteRepository.UpdateCliente(cli);
        }
    }
}