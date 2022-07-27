using System;
namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        public TacoBell()
        {
        }
        public string Name { get; set; }
        public Point Location { get; set; }

        public TacoBell(string name, double latitude, double longitude)
        {
            Name = name;                                                    //parameterized constructor.. when you call Tacobell object
            Location = new Point(latitude, longitude);                      //you must pass in the name, latitude, and longitude to create
        }                                                                   //the object
    }
}

