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
        var response = await GetAsync<AqiIndex?>("/AverageAQI/", new GetAverageAqiRequest()
        {
            Location = new Location(
                39.775379f, // indianapolis
                -86.161407f
            ),
            DateRange = new DateRange(
                new DateTime(2020, 01, 01),
                new DateTime(2020, 12, 31)
            )
        });

        // Assert
        response.Should().NotBeNull();
        // var consumerTestHarness = _testHarness.GetConsumerHarness<Average>();
        // Assert.True(await consumerTestHarness.Consumed.Any<SubmitOrder>(x => x.Context.Message.OrderId == orderId), Is.True);

    }

}