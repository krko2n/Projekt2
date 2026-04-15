using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projekt2.Retention
{
	public class BackupRetention
	{
		[JsonPropertyName("count")]
        public int Count {get; set;} = 5;

		[JsonPropertyName("size")]
		public int Size { get; set; } = 10;

		public BackupRetention() { }

		public BackupRetention(int count, int size)
		{
			Count = count;
			Size = size;
		}
	}
}