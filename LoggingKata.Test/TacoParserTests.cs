using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        //1 for a valid string
        //1 for a empty string
        //1 for a null string
        //1 that has the longitude but doesnt have the latitude


        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)] //valid strings
        [InlineData("34.047374,-84.223918, Taco Bell Alpharetta...", -84.223918)] 
        [InlineData("34.996237,-85.291147,Taco Bell Chattanooga...", -85.291147)] 
        [InlineData("34.761813,-86.590082,Taco Bell Huntsville...", -86.590082)] 

        public void ShouldParseLongitude(string  line, double? expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange

            var tacoParser1 = new TacoParser();

            //Act
            
            var actual = tacoParser1.Parse(line);

            //Assert

            Assert.Equal(expected, actual.Location.Longitude);
        }


        //TODO: Create a test ShouldParseLatitude

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)] //valid strings
        [InlineData("34.047374,-84.223918, Taco Bell Alpharetta...", 34.047374)] 
        [InlineData("34.996237,-85.291147,Taco Bell Chattanooga...", 34.996237)] 
        [InlineData("34.761813,-86.590082,Taco Bell Huntsville...", 34.761813)] 

        public void ShouldParseLatitude(string line, double? expected)
        {

            //Arrange
            var tacoParser2 = new TacoParser();

            //Act
            var actual = tacoParser2.Parse(line);

            //Assert

            Assert.Equal(expected, actual.Location.Latitude);

        }
    }
}
