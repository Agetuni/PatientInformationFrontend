using Company.Infrastructure.HttpService.Models;
using Microsoft.Extensions.Configuration;
using PatientInformation.Application.Dto;
using PatientInfrastructure.Application.Dto;
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
        Task<PatientInformationResponse> Add(PatientInformationRequest request);
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

        public async Task<PatientInformationResponse> Add(PatientInformationRequest request)
        {
            return await _httpService.SendAsync<PatientInformationResponse>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data=request,
                Url = $"{ _configuration["patientInformationAPI:BaseUrl"]}" +
              $"{ _configuration["patientInformationAPI:createPatient"]}"
            }); throw new NotImplementedException();
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
