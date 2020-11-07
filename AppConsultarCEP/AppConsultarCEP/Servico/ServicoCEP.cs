using AppConsultarCEP.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AppConsultarCEP.Servico
{
    public class ServicoCEP
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoPeloCEP(string cep)
        {
            string novaURL = string.Format(EnderecoURL, cep);

            WebClient webClient = new WebClient();
            string retorno = webClient.DownloadString(novaURL);

            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(retorno);

            if (endereco.cep == null)
            {
                return null;
            }

            return endereco;
        }
    }
}
