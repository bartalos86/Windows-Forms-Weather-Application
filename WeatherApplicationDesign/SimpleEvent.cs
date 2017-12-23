using System;


namespace WeatherApplicationDesign
{

   public class SimpleEvent : EventArgs
    {
        
        string City;
        public string city { get { return City; } set { City = value; } }

        public SimpleEvent(string _City)
        {
            city = City;
        }
    }
}
