using Company.Infrastructure.HttpService.Models;

namespace PatientInformation.Application.Dto
{
    public class DiseaseResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public RecordStatus RecordStatus { get; set; }
    }
}
