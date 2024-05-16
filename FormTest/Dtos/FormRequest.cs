using System;
using System.ComponentModel.DataAnnotations;

namespace FormTest.Models
{
    public class FormRequest
    {
        [Required]
        public string ProgramTitle { get; set; } = string.Empty;
        [Required]
        public string ProgramDescription { get; set;} = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public List<AdditionalQuestionRequest>? AdditionalQuestions { get; set; }
        public List<CustomQuestionRequest>? CustomQuestions { get; set; }

    }
}
