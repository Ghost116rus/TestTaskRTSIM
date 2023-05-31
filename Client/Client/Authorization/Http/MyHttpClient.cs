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

        public static ResponseAuthDTO Authorize(string login, string password)
        {
            var request = new RequestLoginDTO { Login = login, Password = password };

            try
            {
                var response = _httpClient.PostAsJsonAsync("https://localhost:7208/TestTaskWebAPI/Auth/Authorize", request)
                    .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ResponseAuthDTO>().Result;

                return response == null ? new ResponseAuthDTO { Success = false} : response;
            }
            catch (Exception)
            {
                return new ResponseAuthDTO { Success = false };
            }
        }

        public static ResponseAuthDTO Registre(int organizationId, string name, string login, string password)
        {
            var request = new RequestRegistreDTO { OrganizationId = organizationId, Name = name, Login = login, Password = password };

            try
            {
                var response = _httpClient.PostAsJsonAsync("https://localhost:7208/TestTaskWebAPI/Auth/Registration", request)
                    .Result.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<ResponseAuthDTO>().Result;

                return response;
            }
            catch (Exception e)
            {
                return new ResponseAuthDTO { Success = false, Message = e.Message };
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
