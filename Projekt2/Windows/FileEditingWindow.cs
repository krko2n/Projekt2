using Projekt2.Presentation.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt2.Presentation.Components;
using System.Windows.Forms;
using Projekt2.JSON_R_W;
using Projekt2.Retention;
using Projekt2.Checking;

namespace Projekt2.Windows
{
    public class FileEditingWindow : BaseWindow
    {

        private Projekt2.Presentation.Components.Button _safeButton;
        private Projekt2.Presentation.Components.Button _correctButton;
        private Projekt2.Presentation.Components.Button _exitButton;
        private Projekt2.Presentation.Components.Button _selectJSON;
        private Projekt2.Presentation.Components.TextBox _pathBoxJSON;
        private Projekt2.Presentation.Components.TextBox _pathBoxSources;
		private Projekt2.Presentation.Components.TextBox _pathBoxTargets;
        private Projekt2.Presentation.Components.TextBox _methodBox;
        private Projekt2.Presentation.Components.TextBox _timingBox;
        private Projekt2.Presentation.Components.TextBox _retentionSizeBox;
		private Projekt2.Presentation.Components.TextBox _retentionCountBox;
		private Projekt2.Presentation.Components.TextBox _whatsWrongBox;



		public FileEditingWindow(string title, Application application, IWindow? returnWindow = null, FileInfo? file = null)
            : base("JSON Editor", application, returnWindow)
        {

            _pathBoxJSON = new Projekt2.Presentation.Components.TextBox("JSON editing file:\t",32);
			_pathBoxSources = new Projekt2.Presentation.Components.TextBox("Source file:\t", 32);
			_pathBoxTargets = new Projekt2.Presentation.Components.TextBox("Target file:\t", 32);
			_methodBox = new Projekt2.Presentation.Components.TextBox("Metod for backup:\t", 32);
			_timingBox = new Projekt2.Presentation.Components.TextBox("Automatic timing:\t", 32);
			_retentionSizeBox = new Projekt2.Presentation.Components.TextBox("Retention size:\t\t", 32);
			_retentionCountBox = new Projekt2.Presentation.Components.TextBox("Retention count:\t", 32);
			_whatsWrongBox = new Projekt2.Presentation.Components.TextBox("Errors", 32);
			_safeButton = new Projekt2.Presentation.Components.Button("Save", true);
			_correctButton = new Projekt2.Presentation.Components.Button("Check", true);
            _selectJSON = new Projekt2.Presentation.Components.Button("Select JSON File");
            _exitButton = new Projekt2.Presentation.Components.Button("Exit", true);



			RegisterComponent(_pathBoxJSON);
            RegisterComponent(_pathBoxSources);
            RegisterComponent(_pathBoxTargets);
            RegisterComponent(_methodBox);
            RegisterComponent(_timingBox);
            RegisterComponent(_retentionSizeBox);
            RegisterComponent(_retentionCountBox);
			RegisterComponent(_whatsWrongBox);

            RegisterComponent(_safeButton);
            RegisterComponent(_correctButton);
            RegisterComponent(_selectJSON);
            RegisterComponent(_exitButton);


			_safeButton.Clicked += _safeButton_Clicked;
			_correctButton.Clicked += CheckButtonClicked;
            _selectJSON.Clicked += SelectJSONButtonClicked;
			_exitButton.Clicked += _exitButton_Clicked;

        }


		public BackupJob Job { get; set; }
        public string PathString { get; set; }
        public string SourceString { get; set; }
        public string TargetString { get; set; }
		public string Error = "none";



		

		private void UpdateFileWalues()
        {
			TargetString = null;
			SourceString = null;
			_pathBoxJSON.Value = PathString;
            _pathBoxSources.Value = UpdateFilePaths(Job.Sources, true);
			_pathBoxTargets.Value = UpdateFilePaths(Job.Targets, false);
            _methodBox.Value = Job.BackupMethod.ToString();
			_timingBox.Value = Job.Timing;
            _retentionSizeBox.Value = Job.Retention.Size.ToString();
			_retentionCountBox.Value = Job.Retention.Count.ToString();
			_whatsWrongBox.Value = Error;



		}

		private void _safeButton_Clicked()
		{
			UpdateFileWaluesV2();
			Writer.Write(PathString, Job);
			MessageBox.Show("Saved succesfuly");
			Console.Clear();
			UpdateFileWalues();

		}

		private void UpdateFileWaluesV2()
		{
			PathString = _pathBoxJSON.Value;
			Job.Sources = ParseFilePaths(_pathBoxSources.Value);
			Job.Targets = ParseFilePaths(_pathBoxTargets.Value);
			Job.BackupMethod = Enum.Parse<BackupMethod>(_methodBox.Value);
			Job.Timing = _timingBox.Value;
			Job.Retention.Size = Convert.ToInt32(_retentionSizeBox.Value);
			Job.Retention.Count = Convert.ToInt32(_retentionCountBox.Value);
			Error = _whatsWrongBox.Value;
			_pathBoxSources.Value = null;
			_pathBoxTargets.Value = null;

			Console.Clear();

			UpdateFileWalues();
		}




		private void CheckButtonClicked()
        {
			UpdateFileWaluesV2();
			(bool isok, string whatswrong) = Syntaxcheck.ValidateJob(Job);
			Error = whatswrong;
			if (isok)
				_safeButton_Clicked();

		}


        private void SelectJSONButtonClicked()
        {
			var dialog = new System.Windows.Forms.OpenFileDialog();
			dialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

			if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				_selectJSON.ChangeName("Change JSON File");
                Console.Clear();
				Job = Reader.Read(dialog.FileName);
				PathString = dialog.FileName;
				UpdateFileWalues();

			}

		}

        private string UpdateFilePaths(List<string> paths, bool isSource)
        {
			Console.Clear();
			foreach (string fp in paths)
			{
				if (isSource)
					SourceString += $" {fp}\n\t\t";
				else
					TargetString += $" {fp}\n\t\t";
			}

            return  isSource ? SourceString : TargetString;

		}

		private List<string> ParseFilePaths(string input)
		{
			return input
				.Split('\n', StringSplitOptions.RemoveEmptyEntries)
				.Select(line => line.Trim())
				.Where(line => line.Length > 0)
				.ToList();
		}




		private void _exitButton_Clicked()
		{
            Close();
		}


	}
}
