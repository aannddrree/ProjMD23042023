using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjMB23042023.Models;
using ProjMB23042023.Services;

namespace ProjMD23042023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get()
        {
            return _addressService.Get();
        }


        [HttpGet("{cep:length(8)}")]
        public ActionResult<AddressDTO> GetPostOffices(string cep)
        {
            //Exemplo de chamada de serviço - TESTE
            return PostOfficesService.GetAddress(cep).Result;
        }



        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id)
        {
            var address = _addressService.Get(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        [HttpPost]
        public ActionResult<Address> Create(Address address)
        {
            _addressService.Create(address);

            return CreatedAtRoute("GetAddress", new { id = address.Id.ToString() }, address);
        }
    }
}
