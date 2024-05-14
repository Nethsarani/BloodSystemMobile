using BloodDonationManamentSystem;
namespace BloodSystemMobile;

[QueryProperty(nameof(donor), "donor")]

public partial class HomePage : ContentPage
{
    DB dB = new DB();
    public Donor donor
    {
        set
        {
            loggedDonor = value;
        }
    }
    public Donor loggedDonor;
    public HomePage()
	{
		InitializeComponent();
        Table.ItemsSource = dB.getRequest();

	}

    private void btnReg_Clicked(object sender, EventArgs e)
    {

    }
}