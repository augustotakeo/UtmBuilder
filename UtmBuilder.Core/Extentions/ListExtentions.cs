namespace UtmBuilder.Core.Extentions;

public static class ListExtentions {

    public static void AddIfNotNull(this List<string> list, string key, string? value) {
        
        if(value.IsNotNullOrEmpty())
            list.Add($"{key}={value}");

    }

}