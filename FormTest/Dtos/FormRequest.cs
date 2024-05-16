using System;
using System.ComponentModel.DataAnnotations;

namespace FormTest.Models
{
    public class FormRequest
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public List<AdditionalQuestion>? AdditionalQuestions { get; set; }
        public List<CustomQuestion>? CustomQuestions { get; set; }

    }
}
