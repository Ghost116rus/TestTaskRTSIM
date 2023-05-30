using Client.Authorization.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Authorization
{
    public static class MyHttpClient
    {
        public static List<Organization> GetOrganizations()
        {
            return new List<Organization>() { new Organization { Id = 1, Name = "Проверка 1" }, new Organization { Id = 2, Name = "Проверка Проверка" } };
        }
        public static List<string> GetLoginsByOrganizationId(int Id)
        {
            return new List<string>() { "Это Http", "Client" };
        }
    }
}
