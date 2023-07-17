namespace webAppTests.Common;

[CollectionDefinition("Test collection")]
public class SharedDatabaseCollection : ICollectionFixture<CustomWebApplicationFactory<Program>>
{
    
}