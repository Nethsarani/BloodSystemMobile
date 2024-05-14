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
        if(loggedDonor != null)
        {
            Table.ItemsSource = dB.getRequests(loggedDonor.BloodType);
            guestpath.IsVisible = false;
            donorpath.IsVisible = true;
        }
        else
        {
            donorpath.IsVisible = false;
            guestpath.IsVisible = true;
        }
        

	}

    private void btnReg_Clicked(object sender, EventArgs e)
    {

    }
}