using Company.Infrastructure.HttpService.Models;
using Newtonsoft.Json;
using PatientInfromation.Infrastructure.Interface;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PatientInfromation.Infrastructure.Service
{
    public class HttpService : IHttpService
    {
        public Response responseModel { get; set; } = new Response();
        private IHttpClientFactory httpClient;
        public HttpService(IHttpClientFactory httpClient) => this.httpClient = httpClient;
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("PatientInformation");
                client.DefaultRequestHeaders.Clear();
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                message.Method = _getMethodType(apiRequest.ApiType);
                message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);
                //
                var response = await client.SendAsync(message);
                if (!response.IsSuccessStatusCode)
                {
                    return default(T);
                }
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);

            }
            catch (Exception ex)
            {
                return (T)(object)new Response
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
                };
            }
        }

        private static HttpMethod _getMethodType(ApiType apiType) =>
            apiType switch
            {
                ApiType.GET => HttpMethod.Get,
                ApiType.POST => HttpMethod.Post,
                ApiType.PUT => HttpMethod.Put,
                ApiType.DELETE => HttpMethod.Delete,
                _ => throw new ArgumentException(message: "Invalid enum value", paramName: nameof(apiType))
            };
    }
}
