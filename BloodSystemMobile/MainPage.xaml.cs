using System.Data;

namespace BloodSystemMobile
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            SemanticScreenReader.Announce(btnLogin.Text);
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        private async void btnReg_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }

        private async void btnGuest_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

    }
}