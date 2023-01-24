using Company.Infrastructure.HttpService.Models;
using System.ComponentModel.DataAnnotations;

namespace PatientInformation.Application.Dto
{
    public class PatientInformationResponse
    {
        public long Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get;  set; }
        [Display(Name = "Disease")]
        public long DiseaseId { get;  set; }
        [Display(Name = "Epilepsy")]
        public Epilepsy Epilepsy { get;  set; }
        public List<PatientAllergyResponse> PatientAllergies { get; set; }
        public List<PatientNCDResponse> PatientNCDs { get; set; }
        public DiseaseResponse Disease { get; set; }
        public PatientInformationResponse()
        {
            PatientAllergies = new List<PatientAllergyResponse>();
            PatientNCDs = new List<PatientNCDResponse>();
        }
    }
    public class PatientAllergyResponse
    {
        public long Id { get; set; }
        public AllergyResponse Allergy { get; set; }
    }
    public class PatientNCDResponse
    {
        public long Id { get; set; }
        public NCDResponse NonCommunicableDisease { get; set; }

    }
}
