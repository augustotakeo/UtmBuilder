using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

public class UrlTests {

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("http://")]
    public void ShouldThrowExceptionWhenUrlIsInvalid(string invalidUrl) {
        Assert.Throws<InvalidUrlException>(() => _ = new Url(invalidUrl));
    }

    [Theory]
    [InlineData("https://www.google.com")]
    public void ShouldNotThrowExceptionWhenUrlIsValid(string validUrl) {
        _ = new Url(validUrl);
    }

}