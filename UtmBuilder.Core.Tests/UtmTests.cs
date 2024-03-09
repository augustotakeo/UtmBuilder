using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests;

public class UtmTests {

    private readonly Url _url = new("https://teste.com/");
    private readonly Campaign _campaign = new("source", "medium", "name", "id", "term", "content");
    private readonly string _address = "https://teste.com/" +
                                        "?utm_source=source" +
                                        "&utm_medium=medium" +
                                        "&utm_name=name" +
                                        "&utm_id=id" +
                                        "&utm_term=term" +
                                        "&utm_content=content";

    [Fact]
    public void ShouldReturnUrlFromUtm() {
        var utm = new Utm(_url, _campaign);
        var address = utm.ToString();
        Assert.Equal(_address, address);
        Assert.Equal(_address, (string)utm);
    }

    [Fact]
    public void ShouldReturnUtmFromUrl() {
        Utm utm = _address;
        Assert.Equal(_url.Address, utm.Url.Address);
        Assert.Equal(_campaign.Source, utm.Campaign.Source);
        Assert.Equal(_campaign.Medium, utm.Campaign.Medium);
        Assert.Equal(_campaign.Name, utm.Campaign.Name);
        Assert.Equal(_campaign.Id, utm.Campaign.Id);
        Assert.Equal(_campaign.Term, utm.Campaign.Term);
        Assert.Equal(_campaign.Content, utm.Campaign.Content);
    }
    
}