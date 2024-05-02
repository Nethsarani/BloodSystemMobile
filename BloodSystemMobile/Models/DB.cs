using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using BloodDonationManamentSystem.Models;
using System.Security.RightsManagement;

namespace BloodDonationManamentSystem
{
    public class DB
    {
        public SqlConnection con = new SqlConnection( @"Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=nethsarani_BloodSystem;Persist Security Info=True;User ID=nethsarani_BloodSystem;Password=neth1234;");
        SqlCommand command;
        public void insertToDatabase(object classobj, string type)
        {
            con.Open();
            
            if (type== "Hospital")
            {
                Hospital obj= ( Hospital )classobj;
                command = new SqlCommand("insert into HospitalTable (Name,RegNo,Location,ContactNo,Email,IsTesting,IsCollecting,OpenTimes,Username,Password,Status) values (@name, @regNo, @location, @contact, @email, @testing, @collecting, @open, @username, @password, @status);", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@name", obj.Name);
                sqlParam1.DbType = DbType.String;
                SqlParameter sqlParam2 = command.Parameters.AddWithValue("@regNo", obj.RegNo);
                sqlParam2.DbType = DbType.String;
                SqlParameter sqlParam3 = command.Parameters.AddWithValue("@location", objToXml(obj.Location));
                sqlParam3.DbType = DbType.Xml;
                SqlParameter sqlParam4 = command.Parameters.AddWithValue("@contact", obj.ContactNo);
                sqlParam4.DbType = DbType.String;
                SqlParameter sqlParam5 = command.Parameters.AddWithValue("@testing", obj.isTesting);
                sqlParam5.DbType = DbType.Boolean;
                SqlParameter sqlParam6 = command.Parameters.AddWithValue("@collecting", obj.isCollecting);
                sqlParam6.DbType = DbType.Boolean;
                SqlParameter sqlParam7 = command.Parameters.AddWithValue("@open", objToXml(obj.OpenTimes));
                sqlParam7.DbType = DbType.Xml;
                SqlParameter sqlParam8 = command.Parameters.AddWithValue("@username", obj.Username);
                sqlParam8.DbType = DbType.String;
                SqlParameter sqlParam9 = command.Parameters.AddWithValue("@password", obj.Password);
                sqlParam9.DbType = DbType.String;
                SqlParameter sqlParam10 = command.Parameters.AddWithValue("@status", "Pending");
                sqlParam10.DbType = DbType.String;
                SqlParameter sqlParam11 = command.Parameters.AddWithValue("@email", obj.Email);
                sqlParam11.DbType = DbType.String;
            }
            else if (type == "DonationCamp")
            {
                DonationCamp obj = (DonationCamp)classobj;
                command = new SqlCommand("insert into DonationCampTable (Name, Date, StartTime, EndTime, ContactNo ,Email, Location, Username, Password, Status) values (@name, @date, @starttime, @endtime, @contact, @email, @location, @username, @password, @status);", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@name", obj.Name);
                sqlParam1.DbType = DbType.String;
                SqlParameter sqlParam2 = command.Parameters.AddWithValue("@date", obj.Date);
                sqlParam2.DbType = DbType.String;
                SqlParameter sqlParam3 = command.Parameters.AddWithValue("@location", objToXml(obj.Location));
                sqlParam3.DbType = DbType.Xml;
                SqlParameter sqlParam4 = command.Parameters.AddWithValue("@contact", obj.ContactNo);
                sqlParam4.DbType = DbType.String;
                SqlParameter sqlParam5 = command.Parameters.AddWithValue("@email", obj.Email);
                sqlParam5.DbType = DbType.String;
                SqlParameter sqlParam6 = command.Parameters.AddWithValue("@starttime", obj.StartTime);
                sqlParam6.DbType = DbType.Date;
                SqlParameter sqlParam7 = command.Parameters.AddWithValue("@endtime", obj.EndTime);
                sqlParam7.DbType = DbType.Date;
                SqlParameter sqlParam8 = command.Parameters.AddWithValue("@username", obj.Username);
                sqlParam8.DbType = DbType.String;
                SqlParameter sqlParam9 = command.Parameters.AddWithValue("@password", obj.Password);
                sqlParam9.DbType = DbType.String;
                SqlParameter sqlParam10 = command.Parameters.AddWithValue("@status", "Pending");
                sqlParam10.DbType = DbType.String;
            }
            else if (type == "Donor")
            {
                Donor obj = (Donor)classobj;
                command = new SqlCommand("insert into DonorTable (Name, Gender, NIC, Location, DOB, ContactNo, Email, BloodType, HealthCondition, Username, Password, Status) values (@name, @gender, @nic, @location, @dob, @contact, @email, @type, @health, @username, @password, @status);", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@name", obj.Name);
                sqlParam1.DbType = DbType.String;
                SqlParameter sqlParam2 = command.Parameters.AddWithValue("@gender", obj.Gender);
                sqlParam2.DbType = DbType.String;
                SqlParameter sqlParam3 = command.Parameters.AddWithValue("@nic", obj.NIC);
                sqlParam3.DbType = DbType.Xml;
                SqlParameter sqlParam4 = command.Parameters.AddWithValue("@location", objToXml(obj.Location));
                sqlParam4.DbType = DbType.String;
                SqlParameter sqlParam5 = command.Parameters.AddWithValue("@dob", obj.DOB);
                sqlParam5.DbType = DbType.String;
                SqlParameter sqlParam6 = command.Parameters.AddWithValue("@contact", obj.ContactNo);
                sqlParam6.DbType = DbType.Date;
                SqlParameter sqlParam7 = command.Parameters.AddWithValue("@email", obj.Email);
                sqlParam7.DbType = DbType.Date;
                SqlParameter sqlParam8 = command.Parameters.AddWithValue("@type", obj.BloodType);
                sqlParam8.DbType = DbType.String;
                SqlParameter sqlParam9 = command.Parameters.AddWithValue("@health", objToXml(obj.health));
                sqlParam9.DbType = DbType.String;
                SqlParameter sqlParam10 = command.Parameters.AddWithValue("@username", obj.Username);
                sqlParam10.DbType = DbType.String;
                SqlParameter sqlParam11 = command.Parameters.AddWithValue("@password", obj.Password);
                sqlParam11.DbType = DbType.String;
                SqlParameter sqlParam12 = command.Parameters.AddWithValue("@status", "Pending");
                sqlParam12.DbType = DbType.String;
            }
            else if (type == "Donation")
            {
                Donation obj = (Donation)classobj;
                command = new SqlCommand("insert into DonationTable (DonorID, Place, Date, Status) values (@donor, @place, @date, @status);", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@donor", obj.Donor.ID);
                sqlParam1.DbType = DbType.Int32;
                SqlParameter sqlParam2 = command.Parameters.AddWithValue("@place", obj.collectionPoint.ID);
                sqlParam2.DbType = DbType.Int32;
                SqlParameter sqlParam3 = command.Parameters.AddWithValue("@date", obj.Date);
                sqlParam3.DbType = DbType.Date;
                SqlParameter sqlParam4 = command.Parameters.AddWithValue("@status", "Pending");
                sqlParam4.DbType = DbType.String;
            }
            else if (type == "Appointment")
            {
                Appointment obj = (Appointment)classobj;
                command = new SqlCommand("insert into AppointmentTable (DonorID, CollectionPointID, Date, Time, Description, Status) values (@donor, @place, @date, @time, @desc, @status);", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@donor", obj.Donor.ID);
                sqlParam1.DbType = DbType.Int32;
                SqlParameter sqlParam2 = command.Parameters.AddWithValue("@place", obj.Place.ID);
                sqlParam2.DbType = DbType.Int32;
                SqlParameter sqlParam3 = command.Parameters.AddWithValue("@date", obj.Date);
                sqlParam3.DbType = DbType.Date;
                SqlParameter sqlParam4 = command.Parameters.AddWithValue("@time", obj.Time);
                sqlParam4.DbType = DbType.Time;
                SqlParameter sqlParam5 = command.Parameters.AddWithValue("@desc", obj.Description);
                sqlParam5.DbType = DbType.String;
                SqlParameter sqlParam6 = command.Parameters.AddWithValue("@status", "Pending");
                sqlParam6.DbType = DbType.String;
            }
            else if (type == "BloodStock")
            {
                BloodStock obj = (BloodStock)classobj;
                command = new SqlCommand("insert into BloodStockTable (Name, Location, Type, Amount, ExpiryDate) values (@name, @location, @type, @amount, @expire);", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@name", obj.Name);
                sqlParam1.DbType = DbType.String;
                SqlParameter sqlParam2 = command.Parameters.AddWithValue("@location", objToXml(obj.Location));
                sqlParam2.DbType = DbType.Xml;
                SqlParameter sqlParam3 = command.Parameters.AddWithValue("@type", obj.BloodType);
                sqlParam3.DbType = DbType.String;
                SqlParameter sqlParam4 = command.Parameters.AddWithValue("@amount", obj.BloodAmount);
                sqlParam4.DbType = DbType.Decimal;
                SqlParameter sqlParam5 = command.Parameters.AddWithValue("@expire", obj.ExpireDate);
                sqlParam5.DbType = DbType.Date;
            }
            else if (type == "Request")
            {
                Request obj = (Request)classobj;
                command = new SqlCommand("insert into RequestTable (HospitalID, Date, BloodType, Amount, Status) values (@hospital, @date, @type, @amount, @status);", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@hospital", obj.Hospital.ID);
                sqlParam1.DbType = DbType.Int32;
                SqlParameter sqlParam2 = command.Parameters.AddWithValue("@date", obj.Date);
                sqlParam2.DbType = DbType.Date;
                SqlParameter sqlParam3 = command.Parameters.AddWithValue("@type", obj.BloodType);
                sqlParam3.DbType = DbType.String;
                SqlParameter sqlParam4 = command.Parameters.AddWithValue("@amount", obj.BloodAmount);
                sqlParam4.DbType = DbType.Decimal;
                SqlParameter sqlParam5 = command.Parameters.AddWithValue("@status", "Pending");
                sqlParam5.DbType = DbType.String;
            }
            else if (type == "HospitalUsers")
            {
                HospitalUser obj = (HospitalUser)classobj;
                command = new SqlCommand("insert into HospitalUsersTable (HospitalID, Name, NIC, Position, ContactNo, Email, Username, Password, Privialges) values (@hospital, @name, @nic, @position, @contact, @email, @username, @password, @privilages );", con);
                command = new SqlCommand("insert into HospitalUsersTable (HospitalID, Name, NIC, Position, ContactNo, Email, Username, Password, Privialges) values (@hospital, @name, @nic, @position, @contact, @email, @username, @password, @privilages );", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@hospital", obj.hospital.ID);
                sqlParam1.DbType = DbType.Int32;
                SqlParameter sqlParam2 = command.Parameters.AddWithValue("@name", obj.Name);
                sqlParam2.DbType = DbType.String;
                SqlParameter sqlParam3 = command.Parameters.AddWithValue("@nic", obj.NIC);
                sqlParam3.DbType = DbType.String;
                SqlParameter sqlParam4 = command.Parameters.AddWithValue("@position", obj.Position);
                sqlParam4.DbType = DbType.String;
                SqlParameter sqlParam5 = command.Parameters.AddWithValue("@contact", obj.ContactNo);
                sqlParam5.DbType = DbType.String;
                SqlParameter sqlParam6 = command.Parameters.AddWithValue("@email", obj.Email);
                sqlParam6.DbType = DbType.String;
                SqlParameter sqlParam7 = command.Parameters.AddWithValue("@username", obj.UserName);
                sqlParam7.DbType = DbType.String;
                SqlParameter sqlParam8 = command.Parameters.AddWithValue("@password", obj.Password);
                sqlParam8.DbType = DbType.String;
                SqlParameter sqlParam9 = command.Parameters.AddWithValue("@privilages", objToXml(obj.Privilages));
                sqlParam9.DbType = DbType.Xml;
            }
            else if (type == "DonationCampUsers")
            {
                DonationCampUser obj = (DonationCampUser)classobj;
                command = new SqlCommand("insert into DonationCampUsersTable (DonationCampID, Name, NIC, Position, ContactNo, Email, Username, Password, Privialges) values (@hospital, @name, @nic, @position, @contact, @email, @username, @password, @privilages );", con);
                SqlParameter sqlParam1 = command.Parameters.AddWithValue("@hospital", obj.donationCamp.ID);
                sqlParam1.DbType = DbType.Int32;
                SqlParameter sqlParam2 = command.Parameters.AddWithValue("@name", obj.Name);
                sqlParam2.DbType = DbType.String;
                SqlParameter sqlParam3 = command.Parameters.AddWithValue("@nic", obj.NIC);
                sqlParam3.DbType = DbType.String;
                SqlParameter sqlParam4 = command.Parameters.AddWithValue("@position", obj.Position);
                sqlParam4.DbType = DbType.String;
                SqlParameter sqlParam5 = command.Parameters.AddWithValue("@contact", obj.ContactNo);
                sqlParam5.DbType = DbType.String;
                SqlParameter sqlParam6 = command.Parameters.AddWithValue("@email", obj.Email);
                sqlParam6.DbType = DbType.String;
                SqlParameter sqlParam7 = command.Parameters.AddWithValue("@username", obj.UserName);
                sqlParam7.DbType = DbType.String;
                SqlParameter sqlParam8 = command.Parameters.AddWithValue("@password", obj.Password);
                sqlParam8.DbType = DbType.String;
                SqlParameter sqlParam9 = command.Parameters.AddWithValue("@privilages", objToXml(obj.Privilages));
                sqlParam9.DbType = DbType.Xml;
            }
            else if (type == "BloodBankUsers")
            {
                User obj = (User)classobj;
                command = new SqlCommand("insert into BloodBankUsersTable (Name, NIC, Position, ContactNo, Email, Username, Password, Privialges) values (@name, @nic, @position, @contact, @email, @username, @password, @privilages );", con);
                SqlParameter sqlParam2 = command.Parameters.AddWithValue("@name", obj.Name);
                sqlParam2.DbType = DbType.String;
                SqlParameter sqlParam3 = command.Parameters.AddWithValue("@nic", obj.NIC);
                sqlParam3.DbType = DbType.String;
                SqlParameter sqlParam4 = command.Parameters.AddWithValue("@position", obj.Position);
                sqlParam4.DbType = DbType.String;
                SqlParameter sqlParam5 = command.Parameters.AddWithValue("@contact", obj.ContactNo);
                sqlParam5.DbType = DbType.String;
                SqlParameter sqlParam6 = command.Parameters.AddWithValue("@email", obj.Email);
                sqlParam6.DbType = DbType.String;
                SqlParameter sqlParam7 = command.Parameters.AddWithValue("@username", obj.UserName);
                sqlParam7.DbType = DbType.String;
                SqlParameter sqlParam8 = command.Parameters.AddWithValue("@password", obj.Password);
                sqlParam8.DbType = DbType.String;
                SqlParameter sqlParam9 = command.Parameters.AddWithValue("@privilages", objToXml(obj.Privilages));
                sqlParam9.DbType = DbType.Xml;
            }
            else
            {
                command = new SqlCommand ();
            }
            command.ExecuteNonQuery();
            con.Close();
        }

        public object takeFromDatabase(string filmname)
        {
            con.Open();
            string sql = string.Format(@"Select * From [FilmTable] Where Film.exist('/Film[name={0}]')=1", filmname);
            SqlCommand abc = new SqlCommand(sql, con);
            SqlDataReader xxx = abc.ExecuteReader();
            object temp = null;
            while (xxx.Read())
            {
                string xml = xxx.GetString(0);
                temp = (object)xmlToObject<object>(xml);
            }
            con.Close();
            return temp;
        }

        static T xmlToObject<T>(string xmlString)
        {
            T classObject;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader stringReader = new StringReader(xmlString))
            {
                classObject = (T)xmlSerializer.Deserialize(stringReader);
            }
            return classObject;
        }

        static string objToXml(object classObject)
        {
            string xmlString = null;
            XmlSerializer xmlSerializer = new XmlSerializer(classObject.GetType());
            using (MemoryStream memoryStream = new MemoryStream())
            {
                xmlSerializer.Serialize(memoryStream, classObject);
                memoryStream.Position = 0;
                xmlString = new StreamReader(memoryStream).ReadToEnd();
            }
            return xmlString;
        }


        public User Login(string username, string password, string type)
        {
            con.Open();
            command = new SqlCommand(@"Select * From ["+type+"Table] Where Username=@username and Password=@password",con);
            SqlParameter sqlParam2 = command.Parameters.AddWithValue("@username", username);
            sqlParam2.DbType = DbType.String;
            SqlParameter sqlParam3 = command.Parameters.AddWithValue("@password", password);
            sqlParam3.DbType = DbType.String;
            SqlDataReader reader = command.ExecuteReader();
            User temp = null;
            while (reader.Read())
            {
                if(type== "HospitalUsers")
                {
                    temp = new HospitalUser();
                }
                else if (type== "DonationCampUsers")
                {
                    temp= new DonationCampUser();
                }
                else
                {
                    temp= new User();
                }
                temp.Id = reader.GetInt32(0);
                temp.Name = reader.GetString(2);
                temp.NIC = reader.GetString(3);
                temp.Position= reader.GetString(4);
                temp.ContactNo = reader.GetString(5);
                temp.Email = reader.GetString(6);
                temp.Password = reader.GetString(8);
                temp.UserName = reader.GetString(7);
                string xml = reader.GetString(9);
                //temp.Privilages = (Privilages)xmlToObject<Privilages>(xml);
            }
            con.Close();
            return temp;
        }

        public Donor DonorLogin(string username, string password)
        {
            con.Open();
            command = new SqlCommand(@"Select * From [DonorsTable] Where Username=@username and Password=@password", con);
            SqlParameter sqlParam2 = command.Parameters.AddWithValue("@username", username);
            sqlParam2.DbType = DbType.String;
            SqlParameter sqlParam3 = command.Parameters.AddWithValue("@password", password);
            sqlParam3.DbType = DbType.String;
            SqlDataReader reader = command.ExecuteReader();
            Donor temp = null;
            while (reader.Read())
            {
                temp = new Donor();
                temp.ID = reader.GetInt32(0);
                temp.Name = reader.GetString(1);
                temp.Gender = reader.GetString(2);
                temp.NIC = reader.GetString(3);
                string xml1 = reader.GetString(4);
                temp.Location= (Location)xmlToObject<Location>(xml1);
                temp.DOB=DateTime.Parse(reader.GetString(5));
                temp.ContactNo = reader.GetString(6);
                temp.Email = reader.GetString(7);
                temp.BloodType = reader.GetString(8);
                temp.health=(HealthCondition)xmlToObject<HealthCondition>(reader.GetString(9));
                temp.Username = reader.GetString(10);
                temp.Password = reader.GetString(11);
            }
            con.Close();
            return temp;
        }
    }
}
