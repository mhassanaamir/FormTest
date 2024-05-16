namespace FormTest.Dtos
{
    public class FormResponse
    {
        public int? Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public List<AdditionalQuestionResponse>? AdditionalQuestionsResponses { get; set; }

        public List<CustomQuestionRersponse>? CustomQuestionsResponses { get; set; }
    }
}
