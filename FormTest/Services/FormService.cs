using FormTest.Models;

namespace FormTest.Services
{
    public class FormService : IFormService
    {
        private readonly CosmosDbContext _db;
        public FormService(CosmosDbContext db) 
        {
            _db = db;
        }

        public async Task<string> CreateFormAsync(FormRequest request)
        {
            var form = new Form()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                CustomQuestions = request.CustomQuestions,
                AdditionalQuestions = request.AdditionalQuestions  
            };

            await _db.AddAsync(form);
            await _db.SaveChangesAsync();

            return "Form created";
        }

        public async Task<Form> GetFormAsync(string id)
        {
            var form = await _db.Forms.FindAsync(id) ?? throw new BadHttpRequestException("Form not found", StatusCodes.Status404NotFound);
            return form;
        }
    }
}
