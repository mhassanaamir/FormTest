﻿using FormTest.Dtos;
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

        [HttpPut("{id}")]
        public async Task<string> UpdateFormAsync(string id, [FromBody] FormRequest request)
        {
            return await _formService.UpdateFormAsync(id, request);
        }

        [HttpPost("submit")]
        public async Task<string> SubmitFormAsync(FormSubmissionRequest request)
        {
            return await _formService.SubmitFormAsync(request);
        }
    }
}
