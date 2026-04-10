using Projekt2.Retention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
			File.WriteAllText(filePath, json);
		}

	}
}
