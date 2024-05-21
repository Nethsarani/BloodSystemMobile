using BloodDonationManamentSystem;
using BloodSystemMobile.Models;

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
        Task.Run(async()=>Table.ItemsSource =await dB.getDonations(loggedDonor.ID));
	}
}