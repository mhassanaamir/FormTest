using FormTest.Enums;

namespace FormTest.Models
{
    public class AdditionalQuestion : BaseEntity
    {
        public QuestionType Type {get; set;}
        public string? Question { get; set; }
        public string? HelperInfo { get; set; }
        public bool IsHidden { get; set; }
        public bool IsInternal { get; set; }
    }
}
