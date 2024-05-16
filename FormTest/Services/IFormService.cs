﻿using FormTest.Dtos;
using FormTest.Models;

namespace FormTest.Services
{
    public interface IFormService
    {
        public Task<string> CreateFormAsync(FormRequest request);
        public Task<string> UpdateFormAsync(int id, FormRequest request);
        public Task<Form> GetFormAsync(int id);
        public Task<string> SubmitFormAsync(FormResponse request);
    }
}
