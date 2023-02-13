using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.DataViewModels;
using Sat.Recruitment.Models;
using Sat.Recruitment.Services.Interface;
using System.Web.Http.Results;

namespace Sat.Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IServiceAdd<AddressVM> _addService;
        private readonly IServiceDelete _deleteService;
        private readonly IServiceGet<Address> _getService;
        private readonly IServiceUpdate<AddressVM> _updateService;

        public AddressController(IServiceAdd<AddressVM> addService,IServiceDelete deleteService,IServiceGet<Address> getService,IServiceUpdate<AddressVM> updateService)
        {
            _addService = addService;
            _deleteService = deleteService;
            _getService = getService;
            _updateService = updateService;
        }

        [HttpGet]
        public async Task<IEnumerable<Address>> Get()
        {
            return await _getService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Address> Get(int id)
        {
            return await _getService.GetByID(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddressVM value)
        {
            var result = _addService.Add(value);
            return result.IsSuccessStatusCode ? Ok(result) : BadRequest(result.ReasonPhrase);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AddressVM value)
        {
            var result = _updateService.Update(value, id);
            return result.IsSuccessStatusCode ? Ok(result) : BadRequest(result.ReasonPhrase); ;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _deleteService.Delete(id);
            return result.IsSuccessStatusCode ? Ok(result) : BadRequest(result.ReasonPhrase);
        }

    }
}
