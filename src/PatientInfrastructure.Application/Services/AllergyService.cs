using Company.Infrastructure.HttpService.Models;
using Microsoft.Extensions.Configuration;
using PatientInformation.Application.Dto;
using PatientInfromation.Infrastructure.Interface;
using PatientInfromation.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInformation.Application.Services
{

    public interface IAllergy
    {
        Task<List<AllergyResponse>> GetAll();
    }
    public class AllergyService: IAllergy
    {
        private readonly IHttpService _httpService;
        private readonly IConfiguration _configuration;
        public AllergyService(IHttpService httpService, IConfiguration configuration)
        {
            _httpService = httpService;
            _configuration = configuration;
        }

        public async Task<List<AllergyResponse>> GetAll()
        {
            return await _httpService.SendAsync<List<AllergyResponse>>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = $"{ _configuration["patientInformationAPI:BaseUrl"]}" +
                $"{ _configuration["patientInformationAPI:getAllAllergy"]}?" +
                $"status=2"
            }); throw new NotImplementedException();
        }
    }
}
