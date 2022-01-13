using System.IO;
using Newtonsoft.Json;

namespace BackupsExtra
{
    public class JsonSaver
    {
        public void SaveBackupJob(BackupJobExtra backupJob, string path)
        {
            string json = JsonConvert.SerializeObject(backupJob, Formatting.Indented, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
            using var streamWriter = new StreamWriter(path);
            streamWriter.WriteLine(json);
        }

        public BackupJobExtra GetBackupJob(string path)
        {
            using var streamReader = new StreamReader(path);
            string json = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<BackupJobExtra>(json);
        }
    }
}