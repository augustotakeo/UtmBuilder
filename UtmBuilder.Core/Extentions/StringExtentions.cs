namespace UtmBuilder.Core.Extentions;

public static class StringExtentions {

    public static bool IsNullOrEmpty(this string? str) => string.IsNullOrEmpty(str);
    public static bool IsNotNullOrEmpty(this string? str) => !string.IsNullOrEmpty(str);

}