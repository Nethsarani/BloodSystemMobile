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
        appoint.Date = (DateTime)pckDate.Date;
        appoint.Time = (TimeSpan)pckTime.Time;
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
    int selectedId = 0;
    public void pckCentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        foreach(KeyValuePair<int,String> item in dic)
        {
            if(item.Value==pckCentre.SelectedItem.ToString())
            {
                selectedId = item.Key;
            }
        }
        if (selectedId % 2 == 0)
        {
            pckDate.MaximumDate=DateTime.Parse(dB.checkTime(selectedId)[0].Date);
            pckDate.MinimumDate = DateTime.Parse(dB.checkTime(selectedId)[0].Date);
            pckTime.MinimumTime=TimeSpan.Parse(dB.checkTime(selectedId)[0].Open);
            pckTime.MaximumTime = TimeSpan.Parse(dB.checkTime(selectedId)[0].Close);
        }
        else
        {
            pckDate.MinimumDate = DateTime.Today;
            pckDate.MaximumDate=default;
        }
        
    }

    private void pckCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        dic = dB.getCentre(pckCity.SelectedItem.ToString());
        List<string> list = dic.Values.ToList();
        pckCentre.ItemsSource = list;
    }

    private void pckDate_SelectionChanged(object sender, EventArgs e)
    {
        if (selectedId%2!=0)
        {
            string Date=pckDate.Date.ToString();
            foreach(TimeRange day in dB.checkTime(selectedId))
            {
                if(Date== day.Date)
                {
                    pckTime.MinimumTime = TimeSpan.Parse(day.Open);
                    pckTime.MaximumTime = TimeSpan.Parse(day.Close);
                }
            }  
        }
    }
}