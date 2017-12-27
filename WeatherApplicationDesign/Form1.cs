using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace WeatherApplicationDesign
{

    public partial class Form1 : Form
    {
        
        Language lang;
        int settingsr;
        string metricorNot;
        Settings jsonSettings;
        public EventHandler<SimpleEvent> eventstart;
        
        #region Deklaration
        dynamic nyelv;
        int tTempMax = 0;
        int tTempMin = 0;
        int tWindSpeed = 0;
        int tHumidity = 0;
        string varos_uni = string.Empty;
        string city;
        dynamic napi;
        string country = "Error";
        int newlang = 0;
        #endregion

        public Form1()
        {
            
            InitializeComponent();
            //All the reading stuff from files
           // Form1_Load(1);



        }
        //When the window loads it gets the current language and gets the settings
        private void Form1_Load(object sender, EventArgs e)
        {

            StreamReader settingsRead = new StreamReader("settings.json");
            StreamReader langRead = new StreamReader("current_lang.txt");
            //Reads the current lang
            string readed = langRead.ReadToEnd();
            //This serializes the settings from file
            jsonSettings = JsonConvert.DeserializeObject<Settings>(settingsRead.ReadToEnd());

            //Decides to use metric or not
            if (jsonSettings.unit == 0)
                metricorNot = "C°";
            else
                metricorNot = "F°";

            label6.Text = metricorNot;

            //Writes the current city to a file
            if (jsonSettings.homeLocation != null)
                OnCitySend(jsonSettings.homeLocation);

            //Sets up Language
            lang = new Language(readed);

            //Disposes the unnecessary resources
            langRead.Dispose();
            settingsRead.Dispose();
            AferFormLoaded(1);
        }

        //After the window is loaded sets up button according to language
        private void AferFormLoaded( int run)
        {

            pinPictureBox.ImageLocation = "Images\\pin.png";
            button1.Text = lang.WeatherButton;
            //Sets the date to Today
           int nap = (int)DateTime.Now.DayOfWeek;
            //If you didnt added home location it will find where you are according to your Ip
            if(jsonSettings.homeLocation == null)
                getWeatherForIpLocation();
            else
            {
                //Gets the weather data for homewlocation
                napi = GetWeather(jsonSettings.homeLocation, null, null, 0);
                if (napi == null)
                {
                    //if there is no such data gets your location and finds the weather for that
                    getWeatherForIpLocation();
                }
                else
                {
                    //Sets the propertiues according to data
                    setData(napi, 25);
                }    
               
            }


            //TODO NYELVET ITT IS BEALLITANI
            //The days got from lang days
            string[] napok = napok = new string[7] { lang.Sunday, lang.Monday, lang.Tuesday, lang.Wednesday, lang.Thursday, lang.Friday, lang.Saturday };

            int b = 1;
            int cnap = 0;

            //Logic for getting the day names in order
            for (int i = 0; i < 4; i++)
            {
                cnap = nap + b;
                if (cnap == 7)
                {
                    b = 0;
                    nap = 0;
                    cnap = 0;
                }

                if (i == 0)
                    label2.Text = napok[cnap];
                if (i == 1)
                    label3.Text = napok[cnap];
                if (i == 2)
                    label4.Text = napok[cnap];
                if (i == 3)
                    label5.Text = napok[cnap];
                b++;
            }

            //if (run == 1)
            //{
            //    // listBox1.SetSelected(0, true);
            //    // comboBox1.SelectedIndex = Properties.Settings.Default.nyelv;
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Writes the current city to a file
            OnCitySend(textBox1.Text);
            //Gets the weather info
            napi = GetWeather(textBox1.Text,null,null,0);
           //Sets the properties accoring to weather data
           setData(napi,25);
            
            //If you wrote a place that dont exists gets the data for your ip
            if (textBox1.Text.Equals(string.Empty))
                pinPictureBox_MouseDown(sender,null);


            //setLanguage(comboBox1.SelectedIndex, 0);
            
                // label4.Text = string.Format($"Wind speed: {wind} km/h");

        }

        //Returns a dinamyc json object with the weather data for the specific location and settings
        dynamic GetWeather(string varos,string koordlat,string koordlong,int ipszam)
        {
            //if the varos isnt empty
            if (varos != string.Empty)
            {
                try
                {
                    string getnapijson = string.Empty;
                    string metricOrNot = null;

                    //Decides according to settings to use C or F
                    if (jsonSettings.unit == 0)
                        metricOrNot = "&units=metric";
                    else
                        metricOrNot = string.Empty;

                    //Its basically decides if youwant to get data with long lat or by city name
                    if (ipszam == 0) //By city name
                     getnapijson = new WebClient().DownloadString($"http://api.openweathermap.org/data/2.5/forecast/daily?q={varos}&mode=json{metricOrNot}&cnt=5&appid=d0f9a1cee42be9d3f4c06858437cd28b");
                    if(ipszam == 1) //By long lat
                        getnapijson = new WebClient().DownloadString($"http://api.openweathermap.org/data/2.5/forecast/daily?lat={koordlat}&lon={koordlong}&cnt=5&mode=json&{metricOrNot}&appid=d0f9a1cee42be9d3f4c06858437cd28b");

                    //Parses the returned data to a dynamic object
                    dynamic napi = JObject.Parse(getnapijson);
                    //dynamic doc = JObject.Parse(getjson);
                    Properties.Settings.Default.city = textBox1.Text;
                    return napi;

                }
                catch (Exception ex)
                {
                    //If there is problem finding city or connection throws an according error message on the selected lang
                    if (ex.Message.Contains("resolved"))
                        MessageBox.Show(lang.connectionFailed, "404 Error", MessageBoxButtons.OK);
                    else
                        MessageBox.Show(lang.cityNotFound, "404 Error", MessageBoxButtons.OK);
                }
            }
            return napi;

        }
        //Sets the the properties according to input data
        void setData(dynamic napi,int tooltip)
        {
            //If input data not equals null
            if (napi != null)
            {
                
                string kepMai = napi.list[1].weather[0].main;
                this.BackgroundImageLayout = ImageLayout.Stretch;

                //Sets the program background to a weather image according to todays weather in the given city
                switch (kepMai)
                {
                    case "Clear":
                        if(this.BackgroundImage != new Bitmap("Images\\Sun-Back.jpg"))
                        this.BackgroundImage = new Bitmap("Images\\Sun-Back.jpg");
                        break;
                    case "Rain":
                        if (this.BackgroundImage != new Bitmap("Images\\Rain-Back.jpg"))
                            this.BackgroundImage = new Bitmap("Images\\Rain-Back.jpg");
                        break;
                    case "Clouds":
                        if (this.BackgroundImage != new Bitmap("Images\\Clouds-Back.jpeg"))
                            this.BackgroundImage = new Bitmap("Images\\Clouds-Back.jpeg");  
                        break;
                    case "Snow":
                        if (this.BackgroundImage != new Bitmap("Images\\Snow-Back.jpg"))
                            this.BackgroundImage = new Bitmap("Images\\Snow-Back.jpg");
                        break;
                }
                //Sets the labels text to the given data
                int temp = napi.list[0].temp.day;
                label1.Text = string.Format($"{temp}");
                windLabel.Text = string.Format($"{lang.windr}{napi.list[0].speed} km/h");
               
                locationLabel.Text = string.Format($"{napi.city.country}, {napi.city.name}");

                tempLabel1.Text = string.Format($"{napi.list[1].temp.day}°");
                tempLabel2.Text = string.Format($"{napi.list[2].temp.day}°");
                tempLabel3.Text = string.Format($"{napi.list[3].temp.day}°");
                tempLabel4.Text = string.Format($"{napi.list[4].temp.day}°");

                minTempLabel.Text = string.Format($"Min: {(int)napi.list[0].temp.min}°");
                maxTempLabel.Text = string.Format($"Max: {(int)napi.list[0].temp.max}°");

                
                GroupBox[] groupboxes = new GroupBox[] { groupBox1, groupBox2, groupBox3, groupBox4 };
                //Fills in the weather descriptiom to each groupbox according to its date and order
                for (int i = 0; i < 4; i++)
                {
                    groupboxes[i].Text = napi.list[i + 1].weather[0].description;
                }

                //Sets the city and country texts to the current country and city
                city = napi.city.name;
                country = napi.city.country;

                PictureBox[] weatherPics = new PictureBox[] { weatherPic1, weatherPic2, weatherPic3, weatherPic4 };

                //Sets up the picture for each picturebox according to the weather for that day
                for (int i = 0; i < 4; i++)
                {
                    string kep = napi.list[i + 1].weather[0].main;
                    switch (kep)
                    {
                        case "Clear":
                            weatherPics[i].SizeMode = PictureBoxSizeMode.StretchImage;
                            weatherPics[i].ImageLocation = "Images\\sun.png";
                          
                            break;
                        case "Rain":
                            weatherPics[i].SizeMode = PictureBoxSizeMode.StretchImage;
                            weatherPics[i].ImageLocation = "Images\\rain.png";
                           
                            break;
                        case "Clouds":
                            weatherPics[i].SizeMode = PictureBoxSizeMode.StretchImage;
                            weatherPics[i].ImageLocation = "Images\\cloud.png";
                            break;
                        case "Snow":
                            weatherPics[i].SizeMode = PictureBoxSizeMode.StretchImage;
                            weatherPics[i].ImageLocation = "Images\\snow.png";
                            break;
                    }
                }
                // kep = napi.list[item].weather[0].main;

            }
        }
        //If the textbox isnt emty remove everything ofrom it on click
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                textBox1.ResetText();

            }
        }
        //Gets the weather data for your ip if you click on the pin
        private void pinPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            getWeatherForIpLocation();
        }
        //Gets your ip through an API
        string getIp()
        {
            try
            {
                var getip = new WebClient().DownloadString($"https://api.ipify.org/?format=text");
                return getip;
            }
            catch { MessageBox.Show(lang.connectionFailed); }
            return null;

        }
        //TODO Delete This
        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
                
           
        }
        //If you hover over this picturebox it will show the corresponding data for that day
        private void weatherPic1_MouseHover(object sender, EventArgs e)
        {
            SetTooltip(weatherPic1);

        }

        void setDataForTooltip(int tooltip)
        {
            try
            {
                //Sets up the data for that tooltip
                tTempMax = napi.list[tooltip + 1].temp.max;
                tTempMin = napi.list[tooltip + 1].temp.min;
                tWindSpeed = napi.list[tooltip + 1].speed;
                tHumidity = napi.list[tooltip + 1].humidity;
            }
            catch { }

        }

        void SetTooltip(PictureBox pb)
        {
            PictureBox[] picboxes = new PictureBox[] { weatherPic1, weatherPic2, weatherPic3, weatherPic4 };
            //Gets the position of the given picturebox from the array
            int position = Array.IndexOf(picboxes, pb);
            //This sets up the data for that tooltip
            setDataForTooltip(position);
            //Shows the tooltip on the current language
            if(newlang == 0)
                toolTip1.Show($"{lang.TempMIN}{tTempMin}{metricorNot}\n" +
                    $"{lang.TempMAX}{tTempMax}{metricorNot}\n" +
                    $"{lang.Wind}{tWindSpeed}km/h \n" +
                    $"{lang.Humidity}{tHumidity}%",pb,3500);

        }
        //This will find your IP and find the weatherData for that and will set the data
        void getWeatherForIpLocation()
        {
            //Gets Current IP
            string ip = getIp();

            if (ip != null)
            {
                //Gets the lat and long for the ip with and API
                var getiplocation = new WebClient().DownloadString($"https://ipapi.co/{ip}/latlong/");
                //Splits the lat long
                string[] darabolt = getiplocation.Split(',');
                string lati = darabolt[0];
                string longi = darabolt[1];
                //Gets the weather data for the ip
                dynamic iploc = GetWeather(getiplocation, lati, longi, 1);
              
                napi = iploc;
                //Sets the weather data for the IP
                setData(iploc, 25);

            }
        }

        //
        private void weatherPic2_MouseHover(object sender, EventArgs e)
        {
            SetTooltip(weatherPic2);
        }

        private void weatherPic3_MouseHover(object sender, EventArgs e)
        {
            SetTooltip(weatherPic3);
        }

        private void weatherPic4_MouseHover(object sender, EventArgs e)
        {
            SetTooltip(weatherPic4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           Form2 form = new Form2();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form3().Show();
      
        }
       protected virtual void OnCitySend(string city)
        {
           // eventstart?.Invoke(this, new SimpleEvent("sfwsdfw"));

            StreamWriter cityWrite = new StreamWriter("currentCity.txt");
            
            cityWrite.Write(city);
            cityWrite.AutoFlush = true;
            cityWrite.Dispose();
            
        }

      
    }
}

