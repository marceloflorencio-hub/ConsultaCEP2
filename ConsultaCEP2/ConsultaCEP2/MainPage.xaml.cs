using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultaCEP2.Serviços.Modelo;
using ConsultaCEP2.Serviços;


namespace ConsultaCEP2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            
            BOTAO1.Clicked += BuscarCEP;

        }
        
        private void BuscarCEP(object sender, EventArgs arg)
        {

            string cep = CEP1.Text.Trim();

            if (isValidCEP(cep)) {
                try
                {
                    Endereço end = ViaCEPServiços.BuscarEndereçoViaCEP(cep);

                    if(end != null)
                    {
                        RESULTADO1.Text = string.Format("Endereço: {0}, {1}, {2}, {3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                }catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            }

        }
        private bool isValidCEP(string cep)
        {
            bool valido = true;
            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido !!!  O CEP deve conter 8 caracteres", "OK");

                valido = false;
            }
            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP inválido !!!  O CEP deve ser composto apenas por números", "OK");

                valido = false;
            }
            return valido;
        }
    }
}
