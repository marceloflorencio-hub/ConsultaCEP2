using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ConsultaCEP2.Serviços.Modelo;
using Newtonsoft.Json;


namespace ConsultaCEP2.Serviços.Modelo
{
    public class ViaCEPServiços
    {
        private static string EndereçoURL = "https://viacep.com.br/ws/{0}/json/";


        public static Endereço BuscarEndereçoViaCEP(string cep)
        {
            string NovoEndereçoURL = string.Format(EndereçoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEndereçoURL);

            Endereço end = JsonConvert.DeserializeObject<Endereço>(Conteudo);

            if (end.cep == null) return null;

            return end;
        }

    }
}
