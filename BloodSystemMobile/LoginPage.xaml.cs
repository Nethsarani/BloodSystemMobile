using BloodDonationManamentSystem;

namespace BloodSystemMobile;

public partial class LoginPage : ContentPage
{
	DB dB = new DB();

	public LoginPage()
	{
		InitializeComponent();
        lblError.IsVisible = false;
        
    }
    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        Donor logged=dB.DonorLogin(txtUsername.Text, txtPassword.Text);
        if (logged != null)
        {
            lblError.Text="Username or password is invalid";
            txtPassword.Text = "";
            lblError.IsVisible=true;
        }
        else if(logged.Status=="Pending")
        {
            lblError.Text = "Your account is still not approved";
            lblError.IsVisible = true;

        }

        else if (logged.Status=="Active")
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        else
        {
            lblError.Text = "There is some error with login. Please try again.";
            txtPassword.Text = "";
            lblError.IsVisible = true;
        }
    }

    private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
    {
        lblError.IsVisible=false;
    }

    private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
    {
        lblError.IsVisible = false;
    }
}