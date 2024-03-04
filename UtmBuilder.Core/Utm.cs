using UtmBuilder.Core.Extentions;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core;

public class Utm(Url url, Campaign campaign) {

    public Url Url { get; set; } = url;

    public Campaign Campaign { get; set; } = campaign;

    public static implicit operator string(Utm utm) => utm.ToString();

    public override string ToString()
    {
        var parameters = new List<string>();
        parameters.AddIfNotNull("utm_source", Campaign.Source);
        parameters.AddIfNotNull("utm_medium", Campaign.Medium);
        parameters.AddIfNotNull("utm_name", Campaign.Name);
        parameters.AddIfNotNull("utm_id", Campaign.Id);
        parameters.AddIfNotNull("utm_term", Campaign.Term);
        parameters.AddIfNotNull("utm_content", Campaign.Content);
        return $"{Url.Address}?{string.Join("&", parameters)}";
    }

}