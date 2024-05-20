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

        public async void insertToDatabase(object classobj, string type)
        {

            if (type == "Hospital")
            {
                Hospital obj = (Hospital)classobj;
                await _connection.InsertAsync(obj);
                
            }
            else if (type == "DonationCamp")
            {
                DonationCamp obj = (DonationCamp)classobj;
                await _connection.InsertAsync(obj);
            }
            else if (type == "Donor")
            {
                Donor obj = (Donor)classobj;
                await _connection.InsertAsync(obj);
            }
            else if (type == "Donation")
            {
                Donation obj = (Donation)classobj;
                await _connection.InsertAsync(obj);
            }
            else if (type == "Appointment")
            {
                Appointment obj = (Appointment)classobj;
                await _connection.InsertAsync(obj);
            }
            else if (type == "BloodStock")
            {
                BloodStock obj = (BloodStock)classobj;
                await _connection.InsertAsync(obj);
            }
            else if (type == "Request")
            {
                Request obj = (Request)classobj;
                await _connection.InsertAsync(obj);
            }
            else if (type == "HospitalUsers")
            {
                HospitalUser obj = (HospitalUser)classobj;
                await _connection.InsertAsync(obj);
            }
            else if (type == "DonationCampUsers")
            {
                DonationCampUser obj = (DonationCampUser)classobj;
                await _connection.InsertAsync(obj);
            }
            else if (type == "BloodBankUsers")
            {
                User obj = (User)classobj;
                await _connection.InsertAsync(obj);
            }
            
            
        }

        public async Task<bool> userCheck(string type, string username)
        {
          List<int> x= new List<int>();
            x[0] = 0;
          x=await _connection.QueryAsync<int>("Select Count(ID) from " + type + "Table WHERE Username=?;",username);
            bool available = true;
            if (x[0] > 0)
            {
                available = false;
            }
            return available;
        }

        public async Task<int> IDCheck(string type, string value, string property)
        {
          List<int> x = new List<int>();
            x = await _connection.QueryAsync<int>("Select ID from " + type + "Table WHERE ? =? ;",property,value);
            return x[0];
        }

        public async Task<List<string>> getDistrict()
        {
          List<string> x = new List<string>();
            await _connection.
            x = await _connection.QueryAsync("Select name_en from districtsTable;");
            return x;
        }

        public async Task<List<string>> getCity(string district)
        {
            int disID = int.Parse(IDCheck("districts", district, "name_en").ToString());
            List<string> x = new List<string>();
            x = await _connection.QueryAsync<string>("Select name_en from citiesTable WHERE district_id=?;",disID);
            return x;
        }

        public async Task<Dictionary<int, string>> getCentre(string city)
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            List<KeyValuePair<int, string>> li = new List<KeyValuePair<int, string>>();
            li= await _connection.QueryAsync<KeyValuePair<int,string>>(@"Select ID,Name From [HospitalTable] Where Location.exist('/Location[City={?}]')=1", city);

            list = li.ToDictionary<int, string>(IEnumerable<KeyValuePair<int,string>>);

            list = await _connection.QueryAsync<KeyValuePair<int, string>>(@"Select ID,Name From [DonationCampTable] Where Location.exist('/Location[City={0}]')=1", city);

            
            return list;
        }

        public async Task<List<TimeRange>> checkTime(int id)
        {
            List<TimeRange> x = new List<TimeRange>();
            if (id % 2 == 0)
            {
                x = await _connection.QueryAsync<TimeRange>("Select Date,StartTime,EndTime from DonationCampTable WHERE IDd=?;",id);
            }
            else
            {
                List<string> xml = await _connection.QueryAsync<String>("Select OpenTimes from HospitalTable WHERE ID=?;", id);

                foreach (string s in xml)
                {
                    x.Add(xmlToObject<TimeRange>(s));
                }
                
            }
            return x;
        }

        public async Task<List<Request>> getRequests(string blood)
        {
          List<Request> x = new List<Request>();
            x = await _connection.QueryAsync<Request>("Select HospitalID, Amount from RequestTable WHERE BloodType=? AND Status='Pending';",blood);
            return x;
        }

        public async Task<List<Donation>> getDonations(int id)
        {
          List<Donation> x = new List<Donation>();
            x = await _connection.QueryAsync<Donation>("Select CollectionPointID,Date from DonationTable WHERE DonorID=?;",id);
            return x;
        }

        public async Task<Hospital> getHospital(int id)
        {
          List<Hospital> x = new List<Hospital>();
          x = await _connection.QueryAsync<Hospital>("Select * from HospitalTable WHERE ID=?;", id);
            
            return x[0];
        }

        public async Task<DonationCamp> getDonationCamp(int id)
        {
            List<DonationCamp> x = new List<DonationCamp>();
            x = await _connection.QueryAsync<DonationCamp>("Select * from DonationCampTable WHERE ID=?;", id);
            return x[0];
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

        public async Task<Donor> DonorLogin(string username, string password)
        {
            List<Donor> temp = null;
            temp = await _connection.QueryAsync<Donor>(@"Select * From DonorTable Where Username=? and Password=?", username,password);
            return temp[0];
        }

        
    }
}
