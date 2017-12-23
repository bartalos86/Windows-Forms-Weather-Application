using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace WeatherApplicationDesign
{
    public partial class Form2 : Form
    {
        Language info;
        bool didSomething = false;
        int unit;
        string DefaultCity;
        public Form2()
        {
            InitializeComponent();


            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            StreamReader settings = new StreamReader("settings.json");
            StreamReader swr2 = new StreamReader("current_lang.txt");

            info = new Language(swr2.ReadToEnd());
            setLanguageStuff();

           

            Settings loadeds = JsonConvert.DeserializeObject<Settings>(settings.ReadToEnd());

            textBox1.Text = loadeds.homeLocation;

            settings.Dispose();
            swr2.Dispose();

            if (loadeds.unit == 0)
                celsiusButton.Select();
            else
                fahrenButton.Select();

           

            switch (info.language)
            {
                case "hu":
                    comboBox1.SelectedIndex = 0;
                    break;
                case "en":
                    comboBox1.SelectedIndex = 1;
                    break;
                default:
                    comboBox1.Text = "Custom";
                    break;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = "C:\\Users\\barta\\Documents\\Visual Studio 2017\\Projects\\WeatherApplicationDesign\\WeatherApplicationDesign";
            openFileDialog1.Filter = "JSON File  (*.json)|*.json";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                didSomething = true;
                StreamReader sr = new StreamReader(openFileDialog1.OpenFile());
                string readed = sr.ReadToEnd();
                info = new Language(readed);

                sr.Dispose();
                
                StreamWriter swr = new StreamWriter("current_lang.txt");

                swr.Write(readed);
                swr.AutoFlush = true;
                swr.Close();


            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox selected = (ComboBox)sender;
            int index = selected.SelectedIndex;
            StreamReader sr;
            StreamWriter sw = new StreamWriter("current_lang.txt");
            string readed;
            switch (index)
            {
                case 0:
                    
                    sr = new StreamReader("langs\\hu_lang.json");
                    readed = sr.ReadToEnd();
                    info = new Language(readed);
                    sr.Dispose();
                    sw.Write(readed);
                    sw.AutoFlush = true;
                    sw.Close();
                    break;
                case 1:
                    
                    sr = new StreamReader("langs\\eng_lang.json");
                    readed = sr.ReadToEnd();
                    info = new Language(readed);
                    sr.Dispose();
                    sw.Write(readed);
                    sw.AutoFlush = true;
                    sw.Close();       
                    break;

            }

        }

        private void celsiusButton_CheckedChanged(object sender, EventArgs e)
        {
            if (fahrenButton.Checked == true && celsiusButton.Checked == true)
                fahrenButton.Checked = false;
        }

        private void fahrenButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void celsiusButton_Click(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Focused)
                didSomething = true;

            unit = 0;

        }

        private void fahrenButton_Click(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if(rd.Focused)
            didSomething = true;

            unit = 1;
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings settings = new Settings();

            if (DefaultCity != textBox1.Text)
                didSomething = true;

            if (unit == 0)
                settings.unit = 0;
            else
                settings.unit = 1;

           if(didSomething)
                MessageBox.Show(info.langSet);

            if (textBox1.Text != null)
                settings.homeLocation = textBox1.Text;

            string json = JsonConvert.SerializeObject(settings);
            StreamWriter jsonwrite = new StreamWriter("settings.json");
            jsonwrite.AutoFlush = true;
            jsonwrite.Write(json);
            
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            didSomething = true;
        }

        void setLanguageStuff()
        {
            button1.Text = info.customFileButton;
            label2.Text = info.unitsLabel;
            homeLabel.Text = info.homeLocationLabel;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DefaultCity = textBox1.Text;        }
    }
    }
