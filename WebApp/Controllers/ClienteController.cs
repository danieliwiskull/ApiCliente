using Microsoft.AspNetCore.Mvc;
using ClassLibraryServices.Contracts;
using WebApp.Models;
using ClassLibraryEntities;
using AutoMapper;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    public class ClienteController : Controller
    {

        private readonly IMapper _Mapper;
        private readonly IClienteService _ClienteService;
        private readonly ILogger<ClienteController> _Logger;

        public ClienteController(IMapper Mapper, IClienteService ClienteService, ILogger<ClienteController> Logger)
        {
            _Mapper = Mapper ?? throw new ArgumentNullException(nameof(Mapper));
            _ClienteService = ClienteService ?? throw new ArgumentNullException(nameof(ClienteService));
            _Logger = Logger ?? throw new ArgumentNullException(nameof(Logger));
        }

        [HttpGet]
        [Route("Obtener/{Id}")]
        public ActionResult<ClienteViewModel> ObtenerCliente(int Id)
        {
            try
            {
                IEnumerable<Cliente> entity = _ClienteService.ObtenerCliente(Id);
                List<ClienteViewModel> model = _Mapper.Map<List<ClienteViewModel>>(entity.ToList());

                if (model.Count == 0)
                    return NotFound(string.Format("Cliente con ID: {0} no existe.",Id));

                return Ok(model);
            }
            catch (Exception ex)
            {
                _Logger.LogError(string.Format("Error: {0}",ex.Message));
                return BadRequest("Ocurrió un error al obtener el cliente.");
            }
        }

        [HttpPost]
        [Route("Insertar")]
        public IActionResult InsertCliente([FromBody] Cliente cli)
        {
            try
            {
                IEnumerable<Cliente> entity = _ClienteService.ObtenerCliente(cli.Id);
                List<ClienteViewModel> model = _Mapper.Map<List<ClienteViewModel>>(entity.ToList());

                if (model.Count > 0)
                    return NotFound(string.Format("Cliente con ID: {0} ya se encuentra registrado.", cli.Id));

                _ClienteService.InsertCliente(cli);
                return Ok(string.Format("Cliente con ID: {0} ha sido agregado con éxito",cli.Id));
            }
            catch (Exception ex)
            {
                _Logger.LogError(string.Format("Error: {0}", ex.Message));
                return BadRequest("Ocurrió un error al insertar el cliente.");
            }
        }

        [HttpPost]
        [Route("Actualizar")]
        public IActionResult LogErrores([FromBody] Cliente cli)
        {
            try
            {
                IEnumerable<Cliente> entity = _ClienteService.ObtenerCliente(cli.Id);
                List<ClienteViewModel> model = _Mapper.Map<List<ClienteViewModel>>(entity.ToList());

                if (model.Count == 0)
                    return NotFound(string.Format("Cliente con ID: {0} no existe.", cli.Id));

                _ClienteService.UpdateCliente(cli);
                return Ok(string.Format("Cliente con ID: {0} ha sido actualizado con éxito", cli.Id));
            }
            catch (Exception ex)
            {
                _Logger.LogError(string.Format("Error: {0}", ex.Message));
                return BadRequest("Ocurrió un error al actualizar el cliente.");
            }
        }
    }
}
