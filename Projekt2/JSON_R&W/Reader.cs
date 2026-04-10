using Projekt2.Retention;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Projekt2.JSON_R_W
{
	public class Reader
	{
		public static BackupJob Read(string filePath)
		{
			string jsonFileAllText = File.ReadAllText(filePath);

			JsonSerializerOptions options = new JsonSerializerOptions
			{
				Converters = { new JsonStringEnumConverter() },
				PropertyNameCaseInsensitive = true
			};



			BackupJob job = JsonSerializer.Deserialize<BackupJob>(jsonFileAllText, options)
				?? throw new Exception("Failed to deserialize JSON file.");

			return job;
		}
	}

}
