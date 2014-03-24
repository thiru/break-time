using System;
using System.Threading;
using System.Windows.Forms;

namespace BreakTime.Windows.Shell
{
  /// <summary>
  /// The splash screen.
  /// </summary>
  public partial class Splash : Form
  {
    /// <summary>
    /// Initialises a new instance of this class.
    /// </summary>
    public Splash()
    {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
      ClientSize = BackgroundImage.Size;
      new Thread(HideWindow).Start();

      base.OnLoad(e);
    }

    private void HideWindow()
    {
      Thread.Sleep(1000);
      Invoke((Action)Close);
    }
  }
}
