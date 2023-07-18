using SharedModels;
using FluentAssertions;
using webAppTests.Common;

namespace webAppTests;

public class GetAverageAQIController : BaseTest
{
    public GetAverageAQIController(CustomWebApplicationFactory<Program> apiFactory) : base(apiFactory)
    {
    }
    
    [Fact]
    public async Task Should_Get_AverageAQIAsync()
    {
        // Act
        var response = await PostAsync<AqiIndex?>("/AverageAQI", new GetAverageAqiRequest()
        {
            Location = new Location(){
                Long= 39.775379f, // indianapolis
                Lat= -86.161407f
            },
            DateRange = new DateRange(
                new DateTime(2020, 01, 01),
                new DateTime(2020, 12, 31)
            )
        });

        // Assert
        response.Should().NotBeNull();
    }

}