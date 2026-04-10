using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projekt2.Retention
{
	public class BackupJob
	{
		[JsonPropertyName("sources")]
		public List<string> Sources { get; set; }

		[JsonPropertyName("targets")]
		public List<string> Targets { get; set; }

		[JsonPropertyName("method")]
		public BackupMethod BackupMethod { get; set; }

		[JsonPropertyName("timing")]
		public string Timing { get; set; }

		[JsonPropertyName("retention")]
		public BackupRetention Retention { get; set; }
		public BackupJob(List<string> sources, List<string> targets, BackupMethod backupMethod, string timing, BackupRetention retention)
		{
			BackupMethod = backupMethod;
			Sources = sources;
			Targets = targets;
			Timing = timing;
			Retention = retention;
		}
	}
}
