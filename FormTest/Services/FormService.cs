using FormTest.Dtos;
using FormTest.Enums;
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
            List<CustomQuestion> customQuestions = [];
            List<AdditionalQuestion> additionalQuestions = [];

            foreach(var customQuestion in request.CustomQuestions ?? [])
            {

                if(customQuestion.Choices != null && !new QuestionType[] { QuestionType.Dropdown, QuestionType.MultipleChoice }.Contains(customQuestion.Type))
                    throw new BadHttpRequestException("Choices can only be added in Dropdown, Multiple choice types");

                if(customQuestion.MaxChoices != null && !(customQuestion.Type == QuestionType.MultipleChoice))
                    throw new BadHttpRequestException("Max Choices can only be added for Multiple Choice type");

                customQuestions.Add(new CustomQuestion {
                    Question = customQuestion.Question,
                    Choices = customQuestion.Choices,
                    HelperInfo = customQuestion.HelperInfo,
                    IsOtherEnabled = customQuestion.IsOtherEnabled,
                    MaxChoices = customQuestion.MaxChoices,
                    Type = customQuestion.Type,
                    Id = customQuestions.Count.ToString()
                });

            }

            foreach(var additionalQuestion in request.AdditionalQuestions ?? [])
            {
                if (additionalQuestion.Choices != null && !new QuestionType[] { QuestionType.Dropdown, QuestionType.MultipleChoice }.Contains(additionalQuestion.Type))
                    throw new BadHttpRequestException("Choices can only be added in Dropdown, Multiple choice types");

                if (additionalQuestion.MaxChoices != null && !(additionalQuestion.Type == QuestionType.MultipleChoice))
                    throw new BadHttpRequestException("Max Choices can only be added for Multiple Choice type");

                additionalQuestions.Add(new AdditionalQuestion
                {
                    Question = additionalQuestion.Question,
                    HelperInfo = additionalQuestion.HelperInfo,
                    IsHidden = additionalQuestion.IsHidden,
                    IsInternal = additionalQuestion.IsInternal,
                    Type = additionalQuestion.Type,
                    Id = additionalQuestions.Count.ToString()
                });
            }

            var form = new Form()
            {
                ProgramTitle = request.ProgramTitle,
                ProgramDescription = request.ProgramDescription,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                CustomQuestions = customQuestions,
                AdditionalQuestions = additionalQuestions
            };

            await _db.AddAsync(form);
            await _db.SaveChangesAsync();

            return $"Form created with id:{form.Id}";
        }

        public async Task<Form> GetFormAsync(string id)
        {
            var form = await _db.Forms.FindAsync(id) ?? throw new BadHttpRequestException("Form not found", StatusCodes.Status404NotFound);
            return form;
        }

        public async Task<string> UpdateFormAsync(string id, FormRequest request)
        {
            var form = await _db.Forms.FindAsync(id) ?? throw new BadHttpRequestException("Form not found", StatusCodes.Status404NotFound);

            List<CustomQuestion> customQuestions = [];
            List<AdditionalQuestion> additionalQuestions = [];

            foreach (var customQuestion in request.CustomQuestions ?? [])
            {

                if (customQuestion.Choices != null && !new QuestionType[] { QuestionType.Dropdown, QuestionType.MultipleChoice }.Contains(customQuestion.Type))
                    throw new BadHttpRequestException("Choices can only be added in Dropdown, Multiple choice types");

                if (customQuestion.MaxChoices != null && !(customQuestion.Type == QuestionType.MultipleChoice))
                    throw new BadHttpRequestException("Max Choices can only be added for Multiple Choice type");

                customQuestions.Add(new CustomQuestion
                {
                    Question = customQuestion.Question,
                    Choices = customQuestion.Choices,
                    HelperInfo = customQuestion.HelperInfo,
                    IsOtherEnabled = customQuestion.IsOtherEnabled,
                    MaxChoices = customQuestion.MaxChoices,
                    Type = customQuestion.Type,
                    Id = customQuestions.Count.ToString()
                });

            }

            foreach (var additionalQuestion in request.AdditionalQuestions ?? [])
            {
                if (additionalQuestion.Choices != null && !new QuestionType[] { QuestionType.Dropdown, QuestionType.MultipleChoice }.Contains(additionalQuestion.Type))
                    throw new BadHttpRequestException("Choices can only be added in Dropdown, Multiple choice types");

                if (additionalQuestion.MaxChoices != null && !(additionalQuestion.Type == QuestionType.MultipleChoice))
                    throw new BadHttpRequestException("Max Choices can only be added for Multiple Choice type");

                additionalQuestions.Add(new AdditionalQuestion
                {
                    Question = additionalQuestion.Question,
                    HelperInfo = additionalQuestion.HelperInfo,
                    IsHidden = additionalQuestion.IsHidden,
                    IsInternal = additionalQuestion.IsInternal,
                    Type = additionalQuestion.Type,
                    Id = additionalQuestions.Count.ToString()
                });
            }

            form.ProgramTitle = request.ProgramTitle;
            form.ProgramDescription = request.ProgramDescription;
            form.FirstName = request.FirstName;
            form.LastName = request.LastName;
            form.Email = request.Email;
            form.CustomQuestions = customQuestions;
            form.AdditionalQuestions = additionalQuestions;

            await _db.SaveChangesAsync();

            return "form updated successfully";

        }

        public async Task<string> SubmitFormAsync(FormSubmissionRequest request)
        {
            var submission = new FormResponse
            {
                FormId = request.FormId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                AdditionalQuestionsResponses = request.AdditionalQuestionsResponses,
                CustomQuestionsResponses = request.CustomQuestionsResponses,
                Id = Guid.NewGuid().ToString()
            };

            await _db.FormResponses.AddAsync(submission);

            await _db.SaveChangesAsync();
            return $"Submitted successfully with id:{submission.Id}";
        }
    }
}
