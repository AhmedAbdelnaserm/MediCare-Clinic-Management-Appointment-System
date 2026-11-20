namespace MediCare.Application.Identity.Localization.LocalizationFileReader;

public sealed class LocalizationFileDataDto
{
    public string Key { get; set; } = string.Empty;
    public Dictionary<string, string> LocalizedValue { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}
