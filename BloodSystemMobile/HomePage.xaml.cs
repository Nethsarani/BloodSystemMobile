using BloodDonationManamentSystem;
using BloodSystemMobile.Models;
namespace BloodSystemMobile;

[QueryProperty(nameof(donor), "donor")]

public partial class HomePage : ContentPage
{
    DBService dB = new DBService();
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
            Task.Run(async()=>Table.ItemsSource = await dB.getRequests(loggedDonor.BloodType));
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