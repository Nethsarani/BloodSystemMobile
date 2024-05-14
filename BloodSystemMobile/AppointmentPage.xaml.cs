using BloodDonationManamentSystem;
using BloodDonationManamentSystem.Models;
using System.Xml.Linq;

namespace BloodSystemMobile;

[QueryProperty(nameof(donor),"donor")]

public partial class AppointmentPage : ContentPage
{
    DB dB = new DB();
    Dictionary<int, String> dic;
    public Donor donor 
    {
        set {
            loggedDonor = value;
        }
    }
    public Donor loggedDonor;
	public AppointmentPage()
	{
        if (loggedDonor.Status == "Pending")
        {
            pckPurpose.SelectedIndex = 0;
            pckPurpose.IsEnabled = false;
        }
		InitializeComponent();
        pckDistrict.ItemsSource = dB.getDistrict();
        
	}

    private async void btnSubmit_Clicked(object sender, EventArgs e)
    {
        Appointment appoint = new Appointment();
        appoint.Donor = loggedDonor;
        appoint.Place=(CollectionPoint)pckCentre.SelectedItem;
        appoint.Date = pckDate.Date;
        appoint.Time = pckTime.Time;
        if (loggedDonor.Status == "Pending")
        {
            dB.insertToDatabase(loggedDonor, "Donor");
            loggedDonor.ID=dB.IDCheck("Donor", loggedDonor.Username, "Username");
        }
        appoint.Description = pckPurpose.SelectedItem.ToString();
        dB.insertToDatabase(appoint,"Appointment");
        if (loggedDonor.Status == "Pending")
        {
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
        else
        {
            var navigationParam = new Dictionary<string, object> { { "donor", loggedDonor } };
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}",navigationParam);
        }
        


    }

    private void pckDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        pckCity.ItemsSource=dB.getCity(pckDistrict.SelectedItem.ToString());
    }

    private void pckCentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedId=0;
        foreach(KeyValuePair<int,String> item in dic)
        {
            if(item.Value==pckCentre.SelectedItem.ToString())
            {
                selectedId = item.Key;
            }
        }
        
    }

    private void pckCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        dic = dB.getCentre(pckCity.SelectedItem.ToString());
        List<string> list = dic.Values.ToList();
        pckCentre.ItemsSource = list;
    }
}