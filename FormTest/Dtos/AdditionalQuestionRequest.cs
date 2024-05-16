using FormTest.Enums;
using System.ComponentModel.DataAnnotations;

namespace FormTest.Models
{
    public class AdditionalQuestionRequest
    {

        [EnumDataType(typeof(QuestionType))]
        public QuestionType Type {get; set;}
        public string? Question { get; set; }
        public string? HelperInfo { get; set; }
        public Dictionary<string, string>? Choices { get; set; }
        public bool? IsOtherEnabled { get; set; }
        public int? MaxChoices { get; set; }
        public bool IsHidden { get; set; }
        public bool IsInternal { get; set; }
    }
}
