using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests;

public class CampaignTests {

    [Theory]
    [InlineData("", "", "")]
    [InlineData("source", "", "")]
    [InlineData("source", "medium", "")]
    public void ShouldThrowExceptionWhenCampaignIsInvalid(string source, string medium, string name) {

        Assert.Throws<InvalidCampaignException>(() => _ = new Campaign(source, medium, name));

    }

    [Theory]
    [InlineData("source", "medium", "name")]
    public void ShouldNotThrowExceptionWhenCampaignIsValid(string source, string medium, string name) {

        _ = new Campaign(source, medium, name);

    }

}