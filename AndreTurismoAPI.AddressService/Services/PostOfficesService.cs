using AndreTurismoAPI.Models;
using Newtonsoft.Json;

namespace AndreTurismoAPI.AddressService.Services
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
