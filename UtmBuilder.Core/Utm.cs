using UtmBuilder.Core.Extentions;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core;

public class Utm(Url url, Campaign campaign) {

    public Url Url { get; set; } = url;

    public Campaign Campaign { get; set; } = campaign;

    public static implicit operator string(Utm utm) => utm.ToString();

    public static implicit operator Utm(string str) {

        InvalidUrlException.ThrowIfInvalid(str);

        var segments = str.Split("?");
        if(segments.Length == 1)
            throw new InvalidUrlException("No parameters were provided");

        var parameters = 
            segments[1].Split("&")
               .Select(x => x.Split("="))
               .ToDictionary(x => x[0], x => x[1]);

        parameters.TryGetValue("utm_source", out string? source);
        parameters.TryGetValue("utm_medium", out string? medium);
        parameters.TryGetValue("utm_name", out string? name);
        parameters.TryGetValue("utm_id", out string? id);
        parameters.TryGetValue("utm_term", out string? term);
        parameters.TryGetValue("utm_content", out string? content);

        source ??= string.Empty;
        medium ??= string.Empty;
        name ??= string.Empty;
        
        var utm = new Utm(
            new Url(segments[0]),
            new Campaign(source, medium, name, id, term, content)
        );

        return utm;
    }

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