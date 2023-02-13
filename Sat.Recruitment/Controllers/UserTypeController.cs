using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.DataViewModels;
using Sat.Recruitment.Models;
using Sat.Recruitment.Services.Interface;

namespace Sat.Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : Controller
    {

        private readonly IServiceAdd<UserTypeVM> _addService;
        private readonly IServiceDelete _deleteService;
        private readonly IServiceGet<UserType> _getService;
        private readonly IServiceUpdate<UserTypeVM> _updateService;

        public UserTypeController(IServiceAdd<UserTypeVM> addService, IServiceDelete deleteService, IServiceGet<UserType> getService, IServiceUpdate<UserTypeVM> updateService)
        {
            _addService = addService;
            _deleteService = deleteService;
            _getService = getService;
            _updateService = updateService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserType>> Get()
        {
            return await _getService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<UserType> Get(int id)
        {
            return await _getService.GetByID(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserTypeVM value)
        {
            var result = _addService.Add(value);
            return result.IsSuccessStatusCode ? Ok(result) : BadRequest(result.ReasonPhrase);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserTypeVM value)
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
