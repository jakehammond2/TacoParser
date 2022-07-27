namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)          //This method returns me an ITrackable Object or Instance
        {
            logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            if (line == null)
            {
                logger.LogWarning("Something went wrong: Length was less than 3");
                return null; 
            }

            if (cells.Length < 3)
            {
                logger.LogFatal("Uh oh. Length was less than 3");
                return null; 
            }

            var latitude = double.Parse(cells[0]);           // We have to parse the string to convert it to a double
            var longitude = double.Parse(cells[1]);
            var name = cells[2];

            ITrackable tacoBell = new TacoBell(name, latitude, longitude);   //Parameterized contructor created in TacoBell
            
            logger.LogInfo($"Finished parsing location {tacoBell.Name}");

            return tacoBell;
        }
    }
}