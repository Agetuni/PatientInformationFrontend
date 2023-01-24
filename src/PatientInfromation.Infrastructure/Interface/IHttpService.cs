using Company.Infrastructure.HttpService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInfromation.Infrastructure.Interface
{
    public interface IHttpService : IDisposable
    {
        Response responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
