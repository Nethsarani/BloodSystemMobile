using BloodDonationManamentSystem;

namespace BloodSystemMobile;

[QueryProperty(nameof(donor), "donor")]
public partial class DonationPage : ContentPage
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
    public DonationPage()
	{
		InitializeComponent();
        Table.ItemsSource = dB.getDonations(loggedDonor.ID);
	}
}