using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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
        public event EventHandler<SimpleEvent> eventstart;
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
           

            
        }

        

        private void Form1_Load( int run)
        {
            button1.Text = lang.WeatherButton;
           int nap = (int)DateTime.Now.DayOfWeek;

            if(jsonSettings.homeLocation == null)
                getWeatherForIpLocation();
            else
            {
                napi = GetWeather(jsonSettings.homeLocation, null, null, 0);
                if (napi == null)
                {
                    getWeatherForIpLocation();
                }
                else
                {
                    setData(napi, 25);
                }    
               
            }


            //TODO NYELVET ITT IS BEALLITANI
            string[] napok = napok = new string[7] { lang.Sunday, lang.Monday, lang.Tuesday, lang.Wednesday, lang.Thursday, lang.Friday, lang.Saturday };

            int b = 1;
            int cnap = 0;

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

            if (run == 1)
            {
                // listBox1.SetSelected(0, true);
                // comboBox1.SelectedIndex = Properties.Settings.Default.nyelv;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            OnCitySend(textBox1.Text);

            napi = GetWeather(textBox1.Text,null,null,0);
           
           setData(napi,25);
            
            if (textBox1.Text.Equals(string.Empty))
                pinPictureBox_MouseDown(sender,null);
            //setLanguage(comboBox1.SelectedIndex, 0);
            
                // label4.Text = string.Format($"Wind speed: {wind} km/h");

        }
        dynamic GetWeather(string varos,string koordlat,string koordlong,int ipszam)
        {

            if (varos != string.Empty)
            {
                try
                {
                    string getnapijson = string.Empty;
                    string metricOrNot = null;
                    if (jsonSettings.unit == 0)
                        metricOrNot = "&units=metric";
                    else
                        metricOrNot = string.Empty;

                    if (ipszam == 0)
                     getnapijson = new WebClient().DownloadString($"http://api.openweathermap.org/data/2.5/forecast/daily?q={varos}&mode=json{metricOrNot}&cnt=5&appid=d0f9a1cee42be9d3f4c06858437cd28b");
                    if(ipszam == 1)
                        getnapijson = new WebClient().DownloadString($"http://api.openweathermap.org/data/2.5/forecast/daily?lat={koordlat}&lon={koordlong}&cnt=5&mode=json&{metricOrNot}&appid=d0f9a1cee42be9d3f4c06858437cd28b");

                    dynamic napi = JObject.Parse(getnapijson);
                    //dynamic doc = JObject.Parse(getjson);
                    Properties.Settings.Default.city = textBox1.Text;
                    return napi;

                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("resolved"))
                        MessageBox.Show(lang.connectionFailed, "404 Error", MessageBoxButtons.OK);
                    else
                        MessageBox.Show(lang.cityNotFound, "404 Error", MessageBoxButtons.OK);
                }
            }
            return napi;

        }

        void setData(dynamic napi,int tooltip)
        {
            if (napi != null)
            {

                int temp = napi.list[0].temp.day;
                label1.Text = string.Format($"{temp}");
                windLabel.Text = string.Format($"{lang.windr}{napi.list[0].speed} km/h");

                pinPictureBox.ImageLocation = "Images\\pin.png";
                locationLabel.Text = string.Format($"{napi.city.country}, {napi.city.name}");

                tempLabel1.Text = string.Format($"{napi.list[1].temp.day}°");
                tempLabel2.Text = string.Format($"{napi.list[2].temp.day}°");
                tempLabel3.Text = string.Format($"{napi.list[3].temp.day}°");
                tempLabel4.Text = string.Format($"{napi.list[4].temp.day}°");

                minTempLabel.Text = string.Format($"Min: {(int)napi.list[0].temp.min}°");
                maxTempLabel.Text = string.Format($"Max: {(int)napi.list[0].temp.max}°");

                GroupBox[] groupboxes = new GroupBox[] { groupBox1, groupBox2, groupBox3, groupBox4 };

                for (int i = 0; i < 4; i++)
                {
                    groupboxes[i].Text = napi.list[i + 1].weather[0].description;
                }
                city = napi.city.name;
                country = napi.city.country;

                PictureBox[] weatherPics = new PictureBox[] { weatherPic1, weatherPic2, weatherPic3, weatherPic4 };

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
                    }
                }
                // kep = napi.list[item].weather[0].main;

            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                textBox1.ResetText();

            }
        }

        private void pinPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            getWeatherForIpLocation();
        }

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

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
                
           
        }

        private void weatherPic1_MouseHover(object sender, EventArgs e)
        {
            SetTooltip(weatherPic1);

        }
        void setDataForTooltip(int tooltip)
        {
            try
            {
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
            int position = Array.IndexOf(picboxes, pb);
            setDataForTooltip(position);
            if(newlang == 0)
                toolTip1.Show($"{lang.TempMIN}{tTempMin}{metricorNot}\n" +
                    $"{lang.TempMAX}{tTempMax}{metricorNot}\n" +
                    $"{lang.Wind}{tWindSpeed}km/h \n" +
                    $"{lang.Humidity}{tHumidity}%",pb,3500);

        }
        void getWeatherForIpLocation()
        {
            string ip = getIp();

            if (ip != null)
            {
                var getiplocation = new WebClient().DownloadString($"https://ipapi.co/{ip}/latlong/");
                string[] darabolt = getiplocation.Split(',');
                string lati = darabolt[0];
                string longi = darabolt[1];

                dynamic iploc = GetWeather(getiplocation, lati, longi, 1);
                napi = iploc;
                setData(iploc, 25);

            }
        }

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

        private void Form1_Load(object sender, EventArgs e)
        {
            

            StreamReader settings = new StreamReader("settings.json");
            StreamReader stread = new StreamReader("current_lang.txt");

            string readed = stread.ReadToEnd();
            jsonSettings = JsonConvert.DeserializeObject<Settings>(settings.ReadToEnd());

            //Decides to use metric orn not
            if (jsonSettings.unit == 0)
                metricorNot = "C°";
            else
                metricorNot = "F°";

            label6.Text = metricorNot;

            if (jsonSettings.homeLocation != null)
                OnCitySend(jsonSettings.homeLocation);

            //Sets up Language
            lang = new Language(readed);

            //Disposes the unnecessary resources
            stread.Dispose();
            settings.Dispose();
            Form1_Load(1);
        }
    }
}

