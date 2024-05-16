using System;

namespace FormTest.Models
{
    public class Form : BaseEntity
    {
        public string ProgramTitle { get; set; } = string.Empty;
        public string ProgramDescription { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<AdditionalQuestion>? AdditionalQuestions { get; set; }
        public List<CustomQuestion>? CustomQuestions { get; set; }
    }
}
