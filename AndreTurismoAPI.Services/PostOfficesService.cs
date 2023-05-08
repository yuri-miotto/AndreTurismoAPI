using AndreTurismoAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAPI.Services
{
    public class PostOfficesService
    {
        static readonly HttpClient endereco = new HttpClient();
        public async Task<EnderecoDTO> GetAddress(string cep)
        {
            try
            {
                HttpResponseMessage response = await PostOfficesService.endereco.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
                response.EnsureSuccessStatusCode();
                string ender = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<EnderecoDTO>(ender);
                return end;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
