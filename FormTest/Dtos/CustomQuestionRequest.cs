using FormTest.Enums;
using System.ComponentModel.DataAnnotations;

namespace FormTest.Models
{
    public class CustomQuestionRequest
    {
        [EnumDataType(typeof(QuestionType))]
        public QuestionType Type {get; set;}
        public string? Question { get; set; }
        public string? HelperInfo { get; set; }
        public Dictionary<int, string>? Choices { get; set; }
        public bool? IsOtherEnabled { get; set; }
        public int? MaxChoices { get; set; }
    }
}
