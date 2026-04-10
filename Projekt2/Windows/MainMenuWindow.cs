using Projekt2.Presentation.Components;
using Projekt2.Presentation.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Projekt2.Windows
{
    public class MainMenuWindow : BaseWindow
    {

        private Projekt2.Presentation.Components.Button _fileButton;
        private Projekt2.Presentation.Components.Button _exitButton;

        public MainMenuWindow(Application application)
            : base("Main Menu", application)
        {

            _fileButton = new Projekt2.Presentation.Components.Button("File");
            _exitButton = new Projekt2.Presentation.Components.Button("Exit");

            RegisterComponent(_fileButton);
            RegisterComponent(_exitButton);

            _fileButton.Clicked += FileButtonClicked;
            _exitButton.Clicked += WindowExit;
            Closed += WindowClosed;
        }

        private void FileButtonClicked()
        {
            IWindow window = new FileEditingWindow("File: ***", _application,this,null);
            window.Show();
        }

        private void WindowExit()
        {
            Close();
        }

        private void WindowClosed()
        {
            _application.Stop();
        }
    }
}
