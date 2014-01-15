using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BreakTime.Windows.Shell
{
  class Program
  {
    /// <summary>
    /// Application entry point.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    [STAThread]
    static void Main(string[] args)
    {
      var trayIcon = new TrayIcon();
      trayIcon.Show();
      Application.Run();
    }
  }
}
