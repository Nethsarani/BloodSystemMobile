using BloodDonationManamentSystem;
using BloodDonationManamentSystem.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BloodSystemMobile.Models
{
    public class DBService
    {
        private const string DBName = "nethsarani_BloodSystem.db";
        private readonly SQLiteAsyncConnection _connection;

        
        public DBService()
        {
            _connection=new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DBName));
        }

        public void insertToDatabase(object classobj, string type)
        {

            if (type == "Hospital")
            {
                Hospital obj = (Hospital)classobj;
                command = new SqlCommand("insert into HospitalTable (Name,RegNo,Location,ContactNo,Email,IsTesting,IsCollecting,OpenTimes,Username,Password,Status) values (@name, @regNo, @location, @contact, @email, @testing, @collecting, @open, @username, @password, @status);", con);
                
            }
            else if (type == "DonationCamp")
            {
                DonationCamp obj = (DonationCamp)classobj;
                command = new SqlCommand("insert into DonationCampTable (Name, Date, StartTime, EndTime, ContactNo ,Email, Location, Username, Password, Status) values (@name, @date, @starttime, @endtime, @contact, @email, @location, @username, @password, @status);", con);
                
            }
            else if (type == "Donor")
            {
                Donor obj = (Donor)classobj;
                command = new SqlCommand("insert into DonorTable (Name, Gender, NIC, Location, DOB, ContactNo, Email, BloodType, HealthCondition, Username, Password, Status) values (@name, @gender, @nic, @location, @dob, @contact, @email, @type, @health, @username, @password, @status);", con);
                
            }
            else if (type == "Donation")
            {
                Donation obj = (Donation)classobj;
                command = new SqlCommand("insert into DonationTable (DonorID, Place, Date, Status) values (@donor, @place, @date, @status);", con);
                
            }
            else if (type == "Appointment")
            {
                Appointment obj = (Appointment)classobj;
                command = new SqlCommand("insert into AppointmentTable (DonorID, CollectionPointID, Date, Time, Description, Status) values (@donor, @place, @date, @time, @desc, @status);", con);
                
            }
            else if (type == "BloodStock")
            {
                BloodStock obj = (BloodStock)classobj;
                command = new SqlCommand("insert into BloodStockTable (Name, Location, Type, Amount, ExpiryDate) values (@name, @location, @type, @amount, @expire);", con);
                
            }
            else if (type == "Request")
            {
                Request obj = (Request)classobj;
                command = new SqlCommand("insert into RequestTable (HospitalID, Date, BloodType, Amount, Status) values (@hospital, @date, @type, @amount, @status);", con);
                
            }
            else if (type == "HospitalUsers")
            {
                HospitalUser obj = (HospitalUser)classobj;
                command = new SqlCommand("insert into HospitalUsersTable (HospitalID, Name, NIC, Position, ContactNo, Email, Username, Password, Privialges) values (@hospital, @name, @nic, @position, @contact, @email, @username, @password, @privilages );", con);
                
            }
            else if (type == "DonationCampUsers")
            {
                DonationCampUser obj = (DonationCampUser)classobj;
                command = new SqlCommand("insert into DonationCampUsersTable (DonationCampID, Name, NIC, Position, ContactNo, Email, Username, Password, Privialges) values (@hospital, @name, @nic, @position, @contact, @email, @username, @password, @privilages );", con);
                
            }
            else if (type == "BloodBankUsers")
            {
                User obj = (User)classobj;
                command = new SqlCommand("insert into BloodBankUsersTable (Name, NIC, Position, ContactNo, Email, Username, Password, Privialges) values (@name, @nic, @position, @contact, @email, @username, @password, @privilages );", con);
                
            }
            else
            {
                command = new SqlCommand();
            }
            
        }

        public async bool userCheck(string type, string username)
        {
          int x=0;
          x=await _connection.QueryAsync<int>("Select Count(ID) from " + type + "Table WHERE Username=@user;");
            bool available = true;
            if (x > 0)
            {
                available = false;
            }
            return available;
        }

        public async int IDCheck(string type, string value, string property)
        {
          int x = 0;
            x = await _connection.QueryAsync<int>("Select ID from " + type + "Table WHERE @property=@value;");
            return x;
        }

        public async List<String> getDistrict()
        {
          List<String> x = new List<string>();
            x = async _connection.QueryAsync<List<string>>("Select name_en from districtsTable;");
            return x;
        }

        public List<String> getCity(String district)
        {
            int disID = IDCheck("districts", district, "name_en");
            command = new SqlCommand("Select name_en from citiesTable WHERE district_id=@id;", con);
            List<String> x = new List<string>();
            while (reader.Read())
            {
                x.Add(reader.GetString(0));
            }
            return x;
        }

        public Dictionary<int, String> getCentre(String city)
        {
            string sql = string.Format(@"Select ID,Name From [HospitalTable] Where Location.exist('/Location[City={0}]')=1", city);

            Dictionary<int, String> list = new Dictionary<int, String>();
            while (reader.Read())
            {
                list.Add(reader.GetInt32(0), reader.GetString(1));

            }
            sql = string.Format(@"Select ID,Name From [DonationCampTable] Where Location.exist('/Location[City={0}]')=1", city);

            while (reader.Read())
            {
                list.Add(reader.GetInt32(0), reader.GetString(1));
            }
            return list;
        }

        public List<TimeRange> checkTime(int id)
        {
            DateTime date;
            TimeSpan start;
            TimeSpan end;
            List<TimeRange> x = new List<TimeRange>();
            if (id % 2 == 0)
            {
                command = new SqlCommand("Select Date,StartTime,EndTime from DonationCampTable WHERE IDd=@id;", con);

                while (reader.Read())
                {
                    TimeRange x1 = new TimeRange();
                    x1.Date = reader.GetDateTime(0).ToString();
                    x1.Open = reader.GetTimeSpan(1).ToString();
                    x1.Close = reader.GetTimeSpan(2).ToString();
                }
            }
            else
            {
                command = new SqlCommand("Select OpenTimes from HospitalTable WHERE ID=@id;", con);

                while (reader.Read())
                {
                    string xml = reader.GetString(0);
                    x.Add(xmlToObject<TimeRange>(xml));
                }
            }
            return x;
        }

        public List<Request> getRequests(String blood)
        {
            command = new SqlCommand("Select HospitalID, Amount from RequestTable WHERE BloodType=@type AND Status='Pending';", con);

            List<Request> x = new List<Request>();
            while (reader.Read())
            {
                Request request = new Request();
                request.Hospital = getHospital(reader.GetInt32(0));
                request.BloodAmount = reader.GetDecimal(1);
                x.Add(request);
            }
            return x;
        }

        public List<Donation> getDonations(int id)
        {
            command = new SqlCommand("Select CollectionPointID,Date from DonationTable WHERE DonorID=@id;", con);

            List<Donation> x = new List<Donation>();
            while (reader.Read())
            {
                Donation don = new Donation();
                if (reader.GetInt32(0) % 2 == 0)
                {
                    don.collectionPoint = getDonationCamp(reader.GetInt32(0));
                }
                else
                {
                    don.collectionPoint = getHospital(reader.GetInt32(0));
                }

                don.Date = reader.GetDateTime(1);
                x.Add(don);
            }
            return x;
        }

        public Hospital getHospital(int id)
        {
            command = new SqlCommand("Select * from HospitalTable WHERE ID=@id;", con);
            Hospital x = new Hospital();
            while (reader.Read())
            {
                x.ID = reader.GetInt32(0);
                x.Name = reader.GetString(1);
                x.RegNo = reader.GetString(2);
                x.Location = xmlToObject<Location>(reader.GetString(3));
                x.ContactNo = reader.GetString(4);
                x.Email = reader.GetString(5);
                x.isTesting = reader.GetBoolean(6);
                x.isCollecting = reader.GetBoolean(7);
                x.OpenTimes = xmlToObject<List<TimeSpan>>(reader.GetString(8));
                x.Username = reader.GetString(9);
                x.Password = reader.GetString(10);
                x.Status = reader.GetString(11);

            }
            return x;
        }

        public DonationCamp getDonationCamp(int id)
        {
            command = new SqlCommand("Select * from DonationCampTable WHERE ID=@id;", con);

            DonationCamp x = new DonationCamp(); ;
            while (reader.Read())
            {
                x.ID = reader.GetInt32(0);
                x.Name = reader.GetString(1);
                x.Date = reader.GetDateTime(2);
                x.StartTime = reader.GetString(3);
                x.EndTime = reader.GetString(4);
                x.ContactNo = reader.GetString(5);
                x.Email = reader.GetString(6);
                x.Location = xmlToObject<Location>(reader.GetString(7));
                x.Username = reader.GetString(8);
                x.Password = reader.GetString(9);
                x.Status = reader.GetString(10);
            }
            return x;
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
            command = new SqlCommand(@"Select * From DonorTable Where Username=@username and Password=@password", con);

            User temp = null;
            while (reader.Read())
            {
                if (type == "HospitalUsers")
                {
                    temp = new HospitalUser();
                }
                else if (type == "DonationCampUsers")
                {
                    temp = new DonationCampUser();
                }
                else
                {
                    temp = new User();
                }
                temp.Id = reader.GetInt32(0);
                temp.Name = reader.GetString(2);
                temp.NIC = reader.GetString(3);
                temp.Position = reader.GetString(4);
                temp.ContactNo = reader.GetString(5);
                temp.Email = reader.GetString(6);
                temp.Password = reader.GetString(8);
                temp.UserName = reader.GetString(7);
                string xml = reader.GetString(9);
                //temp.Privilages = (Privilages)xmlToObject<Privilages>(xml);
            }
            return temp;
        }

        public Donor DonorLogin(string username, string password)
        {
            command = new SqlCommand(@"Select * From DonorTable Where Username=@username and Password=@password", con);

            Donor temp = null;
            while (reader.Read())
            {
                temp = new Donor();
                temp.ID = reader.GetInt32(0);
                temp.Name = reader.GetString(1);
                temp.Gender = reader.GetString(2);
                temp.NIC = reader.GetString(3);
                string xml1 = reader.GetString(4);
                temp.Location = (Location)xmlToObject<Location>(xml1);
                temp.DOB = DateTime.Parse(reader.GetString(5));
                temp.ContactNo = reader.GetString(6);
                temp.Email = reader.GetString(7);
                temp.BloodType = reader.GetString(8);
                temp.health = (HealthCondition)xmlToObject<HealthCondition>(reader.GetString(9));
                temp.Username = reader.GetString(10);
                temp.Password = reader.GetString(11);
                temp.Status = reader.GetString(12);
            }
            return temp;
        }

        public object takeFromDatabase(string filmname)
        {
            string sql = string.Format(@"Select * From [FilmTable] Where Film.exist('/Film[name={0}]')=1", filmname);
            object temp = null;
            while (xxx.Read())
            {
                string xml = xxx.GetString(0);
                temp = (object)xmlToObject<object>(xml);
            }
            return temp;
        }
    }
}
