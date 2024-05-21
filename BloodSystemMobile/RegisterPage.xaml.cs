using BloodDonationManamentSystem;
using BloodSystemMobile.Models;

namespace BloodSystemMobile;

public partial class RegisterPage : ContentPage
{
    DBService dB = new DBService();
    public RegisterPage()
	{
		InitializeComponent();
	}

    private void refresh()
    {
        btnReg.IsEnabled = true;
        if (txtName.Text == "")
        {
            bdrName.Stroke = Color.FromArgb("#FF0000");
            btnReg.IsEnabled= false;
        }
        if (pckDOB.Date == DateTime.Today)
        {
            bdrDOB.Stroke = Color.FromArgb("#FF0000");
            btnReg.IsEnabled = false;
        }
        if (pckGender.SelectedIndex == -1)
        {
            bdrGender.Stroke = Color.FromArgb("#FF0000");
            btnReg.IsEnabled = false;
        }
        if (txtNIC.Text == "")
        {
            bdrNIC.Stroke = Color.FromArgb("#FF0000");
            btnReg.IsEnabled = false;
        }
        if (txtAddress.Text == "")
        {
            bdrAddress.Stroke = Color.FromArgb("#FF0000");
            btnReg.IsEnabled = false;
        }
        if (pckDistrict.SelectedIndex == -1)
        {
            bdrDistrict.Stroke = Color.FromArgb("#FF0000");
            btnReg.IsEnabled = false;
        }
        if (pckCity.SelectedIndex == -1)
        {
            bdrCity.Stroke = Color.FromArgb("#FF0000");
            btnReg.IsEnabled = false;
        }
        if (txtTel.Text == "")
        {
            bdrTel.Stroke = Color.FromArgb("#FF0000");
            btnReg.IsEnabled = false;
        }
        if (txtEmail.Text == "")
        {
            bdrEmail.Stroke = Color.FromArgb("#FF0000");
            btnReg.IsEnabled = false;
        }
        bool a=true;
        Task.Run(async () => a= await dB.userCheck("Donor", txtUsername.Text));
        if (txtUsername.Text == "" || a==false)
        {

          
            bdrUName.Stroke = Color.FromArgb("#FF0000");
            btnReg.IsEnabled = false;
        }
        if (txtPassword.Text == "" || txtPassword.Text.Length<8)
        {
            bdrPass.Stroke = Color.FromArgb("#FF0000");
            btnReg.IsEnabled = false;
        }
        if (txtRePassword.Text != txtPassword.Text)
        {
            bdrRePass.Stroke = Color.FromArgb("#FF0000");
            btnReg.IsEnabled = false;
        }
    }

    private async void btnReg_Clicked(object sender, EventArgs e)
    {
        Donor user = new Donor();
        user.Name = txtName.Text;
        user.DOB =pckDOB.Date;
        user.Gender =pckGender.SelectedItem.ToString();
        user.NIC = txtNIC.Text;
        user.Location.Address =txtAddress.Text;
        user.Location.City =pckCity.SelectedItem.ToString();
        user.Location.District =pckDistrict.SelectedItem.ToString();
        user.ContactNo = txtTel.Text;
        user.Email =txtEmail.Text;
        user.Username =txtUsername.Text;
        user.Password = txtPassword.Text;
        user.Status = "Pending";
        var navigationParam =new Dictionary<string, object> { {"donor",user } };
        await Shell.Current.GoToAsync($"//{nameof(AppointmentPage)}",navigationParam);

    }

    private void txtName_TextChanged(object sender, TextChangedEventArgs e)
    {
        refresh();
    }

    private void pckDOB_DateSelected(object sender, DateChangedEventArgs e)
    {
        refresh();
    }

    private void pckGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        refresh();
    }

    private void txtNIC_TextChanged(object sender, TextChangedEventArgs e)
    {
        refresh();
    }

    private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
    {
        refresh();
    }

    private void pckDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        refresh();
    }

    private void pckCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        refresh();
    }

    private void txtTel_TextChanged(object sender, TextChangedEventArgs e)
    {
        refresh();
    }

    private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
    {
        refresh();
    }

    private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
    {
        refresh();
    }

    private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
    {
        refresh();
    }

    private void txtRePassword_TextChanged(object sender, TextChangedEventArgs e)
    {
        refresh();
    }
}