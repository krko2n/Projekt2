using Projekt2.Retention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2.Checking
{
	public class Syntaxcheck
	{
		public static (bool isValid, string errorMessage) ValidateJob(BackupJob job)
		{
			if (!Enum.IsDefined(typeof(BackupMethod), job.BackupMethod))
				return (false, "Backup method is invalid");

			if (job.Targets == null || job.Targets.Count < 1)
				return (false, "Targets are empty");

			if (job.Sources == null || job.Sources.Count < 1)
				return (false, "Sources are empty");

			if (string.IsNullOrEmpty(job.Timing))
			{
			}
			else
			{
				bool passed = TimerCorrectionSyntaxCheck.IsTimerSyntaxCorrectOrWhereIsWrong(job.Timing);
				if (!passed)
					return (passed, "wrong time");
			}

			if (job.Retention == null)
				return (false, "Retention must contain something");

			if (job.Retention.Count < 1)
				return (false, "Count must be greater than 0");

			if (job.Retention.Size > 1 && job.BackupMethod == BackupMethod.Full)
			{
				job.Retention.Size = 1;
				return (true, "Waring: Size in case of full backup will be set to 1 automatickly");
			}
			else if (job.Retention.Size <= 1 && job.BackupMethod != BackupMethod.Full)
				return (false, "Size must be greater than 1 in case of different backup method than full");

			return (true, "");
		}
	}
}
