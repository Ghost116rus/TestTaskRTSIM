using Client.Authorization.Http.DTO;
using Client.Authorization.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Client.Authorization.Http
{
    public static class MyHttpClient
    {
        private static HttpClient _httpClient = new HttpClient();

        public static bool Authorize(string login, string password)
        {
            var request = new RequestLoginDTO { Login = login, Password = password };

            try
            {
                var response = _httpClient.PostAsJsonAsync("https://localhost:7208/TestTaskWebAPI/Auth/Authorize", request)
                    .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ResponseLoginDTO>().Result;

                return response == null ? false : response.Success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<Organization> GetOrganizations()
        {
            try
            {
                var response = _httpClient.GetAsync("https://localhost:7208/TestTaskWebAPI/Organization/GetOrganizationsList")
                    .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<Organization>>().Result;

                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<string> GetLoginsByOrganizationId(int Id)
        {
            try
            {
                var response = _httpClient.GetAsync($"https://localhost:7208/TestTaskWebAPI/Organization/GetOrganizationLogins?organizationId={Id}")
                    .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<string>>().Result;

                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
