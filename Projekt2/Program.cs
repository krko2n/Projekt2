using Projekt2.Presentation.Windows;
using Projekt2.Windows;

//https://github.com/krko2n/Projekt2
namespace Projekt2
{
    internal class Program
    {
		[STAThread]
		static void Main(string[] args)
        {
            Application app = new Application();

            IWindow window = new MainMenuWindow(app);

            app.Run(window);
        }
    }
}
