using System;
using System.Windows.Forms;

namespace BreakTime.Windows.Shell
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      var splashScreen = new Splash();
      splashScreen.Show();

      var trayIcon = new TrayIcon();
      trayIcon.Show();

      Application.Run();
    }
  }
}
