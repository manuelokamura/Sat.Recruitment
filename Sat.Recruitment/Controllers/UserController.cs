using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Services.Interface;
using Sat.Recruitment.DataViewModels;

namespace Sat.Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IServiceAdd<UserVM> _addService;
        private readonly IServiceDelete _deleteService;
        private readonly IServiceGet<UserVMResponse> _getService;
        private readonly IServiceUpdate<UserVM> _updateService;

        public UserController(IServiceAdd<UserVM> addService, IServiceDelete deleteService,IServiceGet<UserVMResponse> getService,IServiceUpdate<UserVM> updateService)
        {
            _addService = addService;
            _deleteService = deleteService;
            _getService = getService;
            _updateService = updateService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserVMResponse>> Get()
        {
            return await _getService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<UserVMResponse> Get(int id)
        {
            return await _getService.GetByID(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserVM value)
        {
            var result = _addService.Add(value);
            return result.IsSuccessStatusCode ? Ok(result) : BadRequest(result.ReasonPhrase);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserVM value)
        {
            var result = _updateService.Update(value,id);
            return result.IsSuccessStatusCode ? Ok(result) : BadRequest(result.ReasonPhrase);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _deleteService.Delete(id);
            return result.IsSuccessStatusCode ? Ok(result) : BadRequest(result.ReasonPhrase);
        }
    }
}
