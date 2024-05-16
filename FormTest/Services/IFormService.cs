using FormTest.Dtos;
using FormTest.Models;

namespace FormTest.Services
{
    public interface IFormService
    {
        public Task<string> CreateFormAsync(FormRequest request);
        public Task<string> UpdateFormAsync(string id, FormRequest request);
        public Task<Form> GetFormAsync(string id);
        public Task<string> SubmitFormAsync(FormSubmissionRequest request);
    }
}
