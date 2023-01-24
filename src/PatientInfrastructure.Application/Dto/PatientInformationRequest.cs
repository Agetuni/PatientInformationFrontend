using Company.Infrastructure.HttpService.Models;
using System.ComponentModel.DataAnnotations;

namespace PatientInfrastructure.Application.Dto
{
    public class PatientInformationRequest
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Disease")]
        public long Disease { get; set; }

        [Required]
        [Display(Name = "Epilepsy")]
        public Epilepsy Epilepsy { get; set; }

        [Display(Name = "Allergies")]
        public List<long> AllergiesDetails { get; set; }
        [Display(Name = "NCDs")]

        public List<long> NCDsDetails { get; set; }
    }
}
