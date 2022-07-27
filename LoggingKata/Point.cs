namespace LoggingKata
{
    public struct Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Point(double lat, double lon)
        {                                           //Added a parameterized constructor where when I create the point, I am forcing myself                                         
            Latitude = lat;                         //  to give it the latitude and longitude upon instantiation 
            Longitude = lon; 
        }
    }
}