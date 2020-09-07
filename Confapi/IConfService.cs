using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Confapi
{
    public interface IConfService
    {
        void GetInfo();
    }

    public class ConfService : IConfService
    {
        private readonly HttpClient _httpClient;

        public ConfService(HttpClient client)
        {
            _httpClient = client;
        }
        public void GetInfo()
        {
            var x = 0;
        }
    }
}
