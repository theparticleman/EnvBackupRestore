using System.Text.Json;

namespace EnvBackupRestore.Domain;

public class Settings
{
    public string BackupDirectory { get; set; }
    public List<string> FilesToBackUp { get; set; }

    static readonly JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    public static Settings Load()
    {
        var settingsPath = "config.json";
        return JsonSerializer.Deserialize<Settings>(File.ReadAllText(settingsPath), options);
    }
}