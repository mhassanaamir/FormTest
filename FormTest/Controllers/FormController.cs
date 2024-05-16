using FormTest.Models;
using FormTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;
        public FormController(IFormService formService) 
        {
            _formService = formService;
        }

        [HttpPost]
        public async Task<string> CreateFormAsync([FromBody] FormRequest request)
        {
            return await _formService.CreateFormAsync(request);
        }

        [HttpGet("{id}")]
        public async Task<Form> GetFormAsync(string id)
        {
            return await _formService.GetFormAsync(id);
        }
    }
}
