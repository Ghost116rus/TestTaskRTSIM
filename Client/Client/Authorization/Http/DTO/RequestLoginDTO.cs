using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Authorization.Http.DTO
{
    public class RequestLoginDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
