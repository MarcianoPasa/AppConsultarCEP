using Xamarin.Forms;

namespace AppConsultarCEP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppConsultarCEP.View.BuscarCEP();
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
