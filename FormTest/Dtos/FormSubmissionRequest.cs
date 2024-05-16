using System.ComponentModel.DataAnnotations;

namespace FormTest.Dtos
{
    public class FormSubmissionRequest
    {
        [Required]
        public string? FormId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public List<AdditionalQuestionResponse>? AdditionalQuestionsResponses { get; set; }
        public List<CustomQuestionResponse>? CustomQuestionsResponses { get; set; }
    }
}
