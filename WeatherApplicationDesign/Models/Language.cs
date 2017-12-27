using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace WeatherApplicationDesign
{
   public class Language
    {
       //static string json_txt = string.Empty;
        dynamic LangFile;
        public Language(string json_text)
        {
            // MessageBox.Show(json_text);
            try { 
            LangFile = JObject.Parse(json_text);
            }
            catch { MessageBox.Show("Something is wrong with the file!"); }
        }
         
        
        public string language { get { return LangFile.language; } }
        public string TempMAX { get { return LangFile.tempMax; } }
        public string TempMIN { get { return LangFile.tempMin; } }
        public string Wind { get { return LangFile.wind; } }
        public string windr { get { return LangFile.windr; } }
        public string Humidity { get { return LangFile.humidity; } }
        public string Sunday { get { return LangFile.days[0]; } }
        public string Monday { get { return LangFile.days[1]; } }
        public string Tuesday { get { return LangFile.days[2]; } }
        public string Wednesday { get { return LangFile.days[3]; } }
        public string Thursday { get { return LangFile.days[4]; } }
        public string Friday { get { return LangFile.days[5]; } }
        public string Saturday { get { return LangFile.days[6]; } }
        public string WeatherButton { get { return LangFile.weatherButton; } }
        public string cityNotFound { get { return LangFile.cityNotFound; } }
        public string connectionFailed { get { return LangFile.connectionFailed; } }
        public string langSet { get { return LangFile.langSet; } }
        public string customFileButton { get { return LangFile.customFileButton; } }
        public string homeLocationLabel { get { return LangFile.homeLocationLabel; } }
        public string unitsLabel { get { return LangFile.unitsLabel; } }
    }
}
