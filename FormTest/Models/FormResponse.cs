using FormTest.Dtos;

namespace FormTest.Models
{
    public class FormResponse : BaseEntity
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public List<AdditionalQuestionResponse>? AdditionalQuestionsResponses { get; set; }

        public List<CustomQuestionResponse>? CustomQuestionsResponses { get; set; }
    }
}
