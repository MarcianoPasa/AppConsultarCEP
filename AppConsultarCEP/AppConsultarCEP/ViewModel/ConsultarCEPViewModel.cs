using AppConsultarCEP.Modelo;
using AppConsultarCEP.Servico;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppConsultarCEP.ViewModel
{
    class ConsultarCEPViewModel : INotifyPropertyChanged
    {
        public string cepParaBusca { get; set; }

        private bool _carregando;
        public bool Carregando
        {
            get { return _carregando; }
            set
            {
                _carregando = value;
                OnPropertyChanged("Carregando");
            }
        }

        private string _mensagem { get; set; }
        public string Mensagem
        {
            get { return _mensagem; }
            set
            {
                _mensagem = value;
                OnPropertyChanged("Mensagem");
            }
        }

        private bool _exibirMensagem;
        public bool ExibirMensagem
        {
            get { return _exibirMensagem; }
            set
            {
                _exibirMensagem = value;
                OnPropertyChanged("ExibirMensagem");
            }
        }

        private bool _exibirCampos;
        public bool ExibirCampos
        {
            get { return _exibirCampos; }
            set
            {
                _exibirCampos = value;
                OnPropertyChanged("ExibirCampos");
            }
        }

        private bool _mensagemErro;
        public bool MensagemErro
        {
            get { return _mensagemErro; }
            set
            {
                _mensagemErro = value;
                OnPropertyChanged("MensagemErro");
            }
        }

        private string _Cep { get; set; }
        public string Cep
        {
            get { return _Cep; }
            set
            {
                _Cep = value;
                OnPropertyChanged("Cep");
            }
        }

        private string _Logradouro { get; set; }
        public string Logradouro
        {
            get { return _Logradouro; }
            set
            {
                _Logradouro = value;
                OnPropertyChanged("Logradouro");
            }
        }

        private string _Complemento { get; set; }
        public string Complemento
        {
            get { return _Complemento; }
            set
            {
                _Complemento = value;
                OnPropertyChanged("Complemento");
            }
        }

        private string _Bairro { get; set; }
        public string Bairro
        {
            get { return _Bairro; }
            set
            {
                _Bairro = value;
                OnPropertyChanged("Bairro");
            }
        }

        private string _Localidade { get; set; }
        public string Localidade
        {
            get { return _Localidade; }
            set
            {
                _Localidade = value;
                OnPropertyChanged("Localidade");
            }
        }

        private string _Uf { get; set; }
        public string Uf
        {
            get { return _Uf; }
            set
            {
                _Uf = value;
                OnPropertyChanged("Uf");
            }
        }

        private string _Ibge { get; set; }
        public string Ibge
        {
            get { return _Ibge; }
            set
            {
                _Ibge = value;
                OnPropertyChanged("Ibge");
            }
        }

        private string _Gia { get; set; }
        public string Gia
        {
            get { return _Gia; }
            set
            {
                _Gia = value;
                OnPropertyChanged("Gia");
            }
        }

        private string _Ddd { get; set; }
        public string Ddd
        {
            get { return _Ddd; }
            set
            {
                _Ddd = value;
                OnPropertyChanged("Ddd");
            }
        }

        private string _Siafi { get; set; }
        public string Siafi
        {
            get { return _Siafi; }
            set
            {
                _Siafi = value;
                OnPropertyChanged("Siafi");
            }
        }

        public Command BuscarCommand { get; set; }

        public ConsultarCEPViewModel()
        {
            BuscarCommand = new Command(BuscarButton);
        }

        private void BuscarButton()
        {
            Task.Run(() => BuscarCEP()).GetAwaiter().GetResult();
        }

        private async void BuscarCEP()
        {
            Mensagem = "";

            Carregando = true;
            MensagemErro = false;
            ExibirMensagem = false;
            ExibirCampos = false;

            try
            {
                Endereco endereco = new Endereco();
                endereco = await ServicoCEP.BuscarEnderecoPeloCEP(cepParaBusca);

                if (endereco == null || endereco.Cep == null)
                {
                    Mensagem = "O CEP informado não retornou nenhum endereço, verifique";
                    ExibirMensagem = true;
                    return;
                }

                ExibirCampos = true;

                Cep = "CEP: " + (endereco.Cep == "" ? "–" : endereco.Cep);

                Logradouro = "Logradouro: " + (endereco.Logradouro == "" ? "–" : endereco.Logradouro);

                Complemento = "Complemento: " + (endereco.Complemento == "" ? "–" : endereco.Complemento);

                Bairro = "Bairro: " + (endereco.Bairro == "" ? "–" : endereco.Bairro);

                Localidade = "Cidade: " + (endereco.Localidade == "" ? "–" : endereco.Localidade);

                Uf = "UF: " + (endereco.Uf == "" ? "–" : endereco.Uf);

                Ibge = "Código IBGE: " + (endereco.Ibge == "" ? "–" : endereco.Ibge);

                Gia = "Gia: " + (endereco.Gia == "" ? "–" : endereco.Gia);

                Ddd = "DDD: " + (endereco.Ddd == "" ? "–" : endereco.Ddd);

                Siafi = "Siafi: " + (endereco.Siafi == "" ? "–" : endereco.Siafi);
            }
            catch (Exception e)
            {
                Debug.WriteLine("ERRO: " + e.Message);
                MensagemErro = true;
            }
            finally
            {
                Carregando = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
