using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppConsultarCEP.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscarCEP : ContentPage
    {
        public BuscarCEP()
        {
            InitializeComponent();
            BindingContext = new ViewModel.ConsultarCEPViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CEP.Focus();
        }
    }
}