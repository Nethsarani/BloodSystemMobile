using BloodDonationManamentSystem;

namespace BloodSystemMobile;

[QueryProperty(nameof(donor), "donor")]
public partial class DonationPage : ContentPage
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
    public DonationPage()
	{
		InitializeComponent();
        Table.ItemsSource = dB.getDonations(loggedDonor.ID);
	}
}