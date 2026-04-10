using Projekt2.Presentation.Components;

namespace Projekt2.Presentation.Windows
{
    public class DialogWindow : BaseWindow
    {
        private Projekt2.Presentation.Components.Label _questionLabel;
        private Projekt2.Presentation.Components.Button _yesButton;
        private Projekt2.Presentation.Components.Button _noButton;

        public DialogWindow(string title, string question, Application application, IWindow? returnWindow = null) 
            : base(title, application, returnWindow)
        {
            _questionLabel = new Projekt2.Presentation.Components.Label(question);
            _yesButton = new Projekt2.Presentation.Components.Button("Yes", true);
            _noButton = new Projekt2.Presentation.Components.Button("No", true);

            RegisterComponent(_questionLabel);
            RegisterComponent(_yesButton);
            RegisterComponent(_noButton);

            _yesButton.Clicked += Submit;
            _noButton.Clicked += Close;
        }
    }
}
