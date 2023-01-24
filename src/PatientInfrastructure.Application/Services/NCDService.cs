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
    public interface INCD
    {
        Task<List<NCDResponse>> GetAll();
    }
    public class NCDService : INCD
    {
        private readonly IHttpService _httpService;
        private readonly IConfiguration _configuration;
        public NCDService(IHttpService httpService, IConfiguration configuration)
        {
            _httpService = httpService;
            _configuration = configuration;
        }
        public async Task<List<NCDResponse>> GetAll()
        {
            return await _httpService.SendAsync<List<NCDResponse>>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = $"{ _configuration["patientInformationAPI:BaseUrl"]}" +
                $"{ _configuration["patientInformationAPI:getAllNCD"]}?" +
                $"status=2"
            }); throw new NotImplementedException();
        }
    }
}
