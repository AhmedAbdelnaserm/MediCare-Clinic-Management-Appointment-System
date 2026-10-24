using System.Globalization;
using Newtonsoft.Json;

namespace MediCare.Application.Identity.Localization.LocalizationFileReader
{
    public class LocalizationFileReader
    {
        private readonly Dictionary<string, Dictionary<string, string>> _data
            = new(StringComparer.OrdinalIgnoreCase);

        public LocalizationFileReader(params string[] fileNames)
        {
            foreach (var file in fileNames)
                LoadFile(file);
        }

        private void LoadFile(string fileName)
        {
            var basePath = AppContext.BaseDirectory;

            var path = Path.Combine(
                basePath,
                "Localization",
                $"{fileName}.json"
            );

            if (!File.Exists(path))
                return; // ملف مش مطلوب للـ host ده

            var list = JsonConvert.DeserializeObject<List<LocalizationFileDataDto>>(
                File.ReadAllText(path));

            foreach (var item in list)
                _data[item.Key] = item.LocalizedValue;
        }

        public string GetKeyValue(string key, string fallback)
        {
            if (!_data.TryGetValue(key, out var cultures))
                return fallback;

            if (cultures.TryGetValue(
                CultureInfo.CurrentCulture.Name, out var value))
                return value;

            return fallback;
        }
    }
}
