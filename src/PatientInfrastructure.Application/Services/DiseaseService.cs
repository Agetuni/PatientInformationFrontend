using Company.Infrastructure.HttpService.Models;
using Microsoft.Extensions.Configuration;
using PatientInformation.Application.Dto;
using PatientInfromation.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInformation.Application.Services
{
    public interface IDisease
    {
        Task<List<DiseaseResponse>> GetAll();
    }
    public class DiseaseService : IDisease
    {
        private readonly IHttpService _httpService;
        private readonly IConfiguration _configuration;
        public DiseaseService(IHttpService httpService, IConfiguration configuration)
        {
            _httpService = httpService;
            _configuration = configuration;
        }
        public async Task<List<DiseaseResponse>> GetAll()
        {
            return await _httpService.SendAsync<List<DiseaseResponse>>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = $"{ _configuration["patientInformationAPI:BaseUrl"]}" +
                $"{ _configuration["patientInformationAPI:getAllDisease"]}?" +
                $"status=2"
            }); throw new NotImplementedException();
        }
    }
}
