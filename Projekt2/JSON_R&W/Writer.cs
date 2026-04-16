using Projekt2.Retention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projekt2.JSON_R_W
{
	public class Writer
	{
		public static void Write(string filePath, BackupJob job) 
		{
			var options = new JsonSerializerOptions
			{
				WriteIndented = true,
				Converters = { new JsonStringEnumConverter() }
			};

			string json = JsonSerializer.Serialize(job, options);
			if ((new Regex(@"[.json]")).IsMatch(filePath.ToLower()))
				filePath = $"{filePath}\\newJSON.JSON";
			if (!File.Exists(filePath))
			{
				File.Create(filePath).Close();
			}
			File.WriteAllText(filePath, json);
		}

	}
}
