using FormTest.Enums;

namespace FormTest.Models
{
    public class CustomQuestion : BaseEntity
    {
        public QuestionType Type {get; set;}
        public string? Question { get; set; }
        public string? HelperInfo { get; set; }
        public Dictionary<string, string>? Choices { get; set; }
        public bool? IsOtherEnabled { get; set; }
        public int? MaxChoices { get; set; }
    }
}
