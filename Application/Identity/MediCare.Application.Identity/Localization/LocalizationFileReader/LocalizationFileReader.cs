using Newtonsoft.Json;
using System.Globalization;

namespace MediCare.Application.Identity.Localization.LocalizationFileReader;

public sealed class LocalizationFileReader
{
    private readonly Dictionary<string, Dictionary<string, string>> _data =
        new(StringComparer.OrdinalIgnoreCase);

    public LocalizationFileReader(params string[] fileNames)
    {
        foreach (var fileName in fileNames)
            LoadFile(fileName);
    }

    private void LoadFile(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Localization", $"{fileName}.json");
        if (!File.Exists(path))
            return;

        var items = JsonConvert.DeserializeObject<List<LocalizationFileDataDto>>(
            File.ReadAllText(path)) ?? [];

        foreach (var item in items)
        {
            if (string.IsNullOrWhiteSpace(item.Key) || item.LocalizedValue is null)
                continue;

            _data[item.Key] = new Dictionary<string, string>(
                item.LocalizedValue,
                StringComparer.OrdinalIgnoreCase);
        }
    }

    public string GetKeyValue(string key, string fallback)
    {
        if (!_data.TryGetValue(key, out var cultures))
            return fallback;

        var culture = CultureInfo.CurrentUICulture;
        if (cultures.TryGetValue(culture.Name, out var value) ||
            cultures.TryGetValue(culture.TwoLetterISOLanguageName, out value))
            return value;

        return fallback;
    }
}
