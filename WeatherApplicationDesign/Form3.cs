using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace WeatherApplicationDesign
{
    public partial class Form3 : Form
    {
        #region decalaration
        string longitude;
        string latitude;
        string elevation;
        string admin;
        string region;
        string timezone;
        string country;
        dynamic coordjson;
        #endregion
        
        string city;

        

        public Form3()
        {

            Form1 myEvent = new Form1();
            myEvent.eventstart += DataStreamWithEvent;

          //  city = Properties.Resources.varos;
            InitializeComponent();
        }

        
        private void DataStreamWithEvent(object sender, SimpleEvent e)
        {
            MessageBox.Show("Event started");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            StreamReader cityReader = new StreamReader("currentCity.txt");
            city = cityReader.ReadLine();  
            cityReader.Dispose();


            var coordtxt = new WebClient().DownloadString($"http://dataservice.accuweather.com/locations/v1/cities/search?apikey=KPzAwGrw7cAShUHCGmejifFDA1p6Fkue%20&q={city}");
            coordjson = JsonConvert.DeserializeObject(coordtxt);

            try
            { 
                elevation = coordjson[0].GeoPosition.Elevation.Metric.Value;
                country = string.Format($"{coordjson[0].Country.ID},{coordjson[0].Country.LocalizedName}");
                admin = coordjson[0].AdministrativeArea.LocalizedName;
                region = coordjson[0].Region.LocalizedName;
                timezone = coordjson[0].TimeZone.Name;
                latitude = coordjson[0].GeoPosition.Latitude;
                longitude = coordjson[0].GeoPosition.Longitude;
            }
            catch { latitude = "Error"; longitude = "Error"; elevation = "Error"; admin = "Error";region = "Error";
                timezone = "Error";country = "Error";
            };
            
            
            setData();

            pictureBox1.ImageLocation = $"https://maps.googleapis.com/maps/api/staticmap?center={city}&zoom=13&size=273x274&maptype=roadmap&key=AIzaSyAZNjyj5-83J7QLYSJRPbJbHEDNx3PtZK8";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void setData()
        {
            boxElevation.Text = elevation;
            boxCountry.Text = country;
            boxAdmin.Text = admin;
            boxRegion.Text = region;
            boxTmZone.Text = timezone;
            boxLat.Text = latitude;
            boxLong.Text = longitude;
           
        }

        private void boxElevation_TextChanged(object sender, EventArgs e)
        {

        }

        private void boxRegion_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
        }

        private void Form3_Activated(object sender, EventArgs e)
        {
           
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
