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
    public interface IPatient
    {
        Task<List<PatientInformationResponse>> GetAll();
    }

    public class PatientService : IPatient
    {
        private readonly IHttpService _httpService;
        private readonly IConfiguration _configuration;
        public PatientService(IHttpService httpService, IConfiguration configuration)
        {
            _httpService = httpService;
            _configuration = configuration;
        }
        public async Task<List<PatientInformationResponse>> GetAll()
        {
            return await _httpService.SendAsync<List<PatientInformationResponse>>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = $"{ _configuration["patientInformationAPI:BaseUrl"]}" +
                $"{ _configuration["patientInformationAPI:getAllPatient"]}"
            }); throw new NotImplementedException();
        }

    }
}
