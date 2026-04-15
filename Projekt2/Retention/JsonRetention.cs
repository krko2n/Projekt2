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
		public List<string> Sources { get; set; } = new List<string> { "C:\\" };

		[JsonPropertyName("targets")]
		public List<string> Targets { get; set; } = new List<string> { "C:\\" };

		[JsonPropertyName("method")]
		public BackupMethod BackupMethod { get; set; } = Projekt2.Retention.BackupMethod.Full;

		[JsonPropertyName("timing")]
		public string Timing { get; set; } = "30 * * * *";

		[JsonPropertyName("retention")]
		public BackupRetention Retention { get; set; } = new BackupRetention();

		public BackupJob() { }
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
