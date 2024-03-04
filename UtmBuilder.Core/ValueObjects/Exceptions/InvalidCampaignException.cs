using UtmBuilder.Core.Extentions;

namespace UtmBuilder.Core.ValueObjects.Exceptions;

public class InvalidCampaignException(string message = InvalidCampaignException.DefaultErrorMessage) : Exception(message) {

    private const string DefaultErrorMessage = "Invalid campaign parameters";

    public static void ThrowIfNull(string? item, string message = DefaultErrorMessage) {
        if(item.IsNullOrEmpty())
            throw new InvalidCampaignException(message);
    }
}