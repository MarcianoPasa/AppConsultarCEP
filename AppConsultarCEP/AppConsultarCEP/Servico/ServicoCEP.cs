using AppConsultarCEP.Modelo;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppConsultarCEP.Servico
{
    public class ServicoCEP
    {
        private static string enderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public async static Task<Endereco> BuscarEnderecoPeloCEP(string cep)
        {
            string novaURL = string.Format(enderecoURL, cep);

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = await requisicao.GetAsync(novaURL);

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                var conteudo = await resposta.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Endereco>(conteudo);
            }

            return null;
        }
    }
}
