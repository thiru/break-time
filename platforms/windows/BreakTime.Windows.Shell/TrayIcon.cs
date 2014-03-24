using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BreakTime.Windows.Shell
{
  /// <summary>
  /// Encapsulates the system tray icon (aka notify icon).
  /// </summary>
  public class TrayIcon
  {
    #region Init
    private readonly NotifyIcon _notifyIcon;
    private bool _alreadyDisposed;

    /// <summary>
    /// Initialises a new instance of this class.
    /// </summary>
    public TrayIcon()
    {
      _notifyIcon = CreateNotifyIcon();
    }

    /// <summary>
    /// Class destruction and cleanup.
    /// </summary>
    ~TrayIcon()
    {
      Dispose(false);
    }
    #endregion Init ----------------------------------------------------------------------------------------------

    #region Public Methods
    /// <summary>
    /// Show the tray icon.
    /// </summary>
    public void Show()
    {
      if (_alreadyDisposed)
        throw new ObjectDisposedException("_notifyIcon");

      _notifyIcon.Visible = true;
    }

    /// <summary>
    /// Show a brief informational, balloon tip with the specified message.
    /// </summary>
    public void ShowBalloonTip(string message)
    {
      _notifyIcon.ShowBalloonTip(0, "Break Time", message, ToolTipIcon.Info);
    }

    /// <summary>
    /// Dispose of underlying <see cref="NotifyIcon"/>.
    /// </summary>
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    #endregion Public Methods ------------------------------------------------------------------------------------

    #region Non-Public Methods
    /// <summary>
    /// Dispose of underlying <see cref="NotifyIcon"/>.
    /// </summary>
    protected virtual void Dispose(bool isDisposing)
    {
      if (!_alreadyDisposed)
      {
        if (isDisposing)
          _notifyIcon.Dispose();

        _alreadyDisposed = true;
      }
    }

    private NotifyIcon CreateNotifyIcon()
    {
      var notifyIcon = new NotifyIcon
      {
        ContextMenu = new ContextMenu
        (
          new[]
          {
            new MenuItem("Settings", delegate { MessageBox.Show("TODO"); }),
            new MenuItem("Log", delegate { MessageBox.Show("TODO"); }),
            new MenuItem("About", delegate { MessageBox.Show("TODO"); }),
            new MenuItem("-"),
            new MenuItem("Reset", delegate { MessageBox.Show("TODO"); }),
            new MenuItem("-"),
            new MenuItem("Exit", delegate { Dispose(); Application.Exit(); })
          }
        ),
        Icon = new Icon(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "flower.ico")),
        Text = "Break Time",
      };
      notifyIcon.DoubleClick += delegate { MessageBox.Show("TODO"); };
      notifyIcon.MouseMove += NotifyIcon_MouseMove;

      return notifyIcon;
    }

    private void NotifyIcon_MouseMove(object sender, MouseEventArgs e)
    {
      //string message = BreakMessageProvider.I.TimeToNextBreak + Environment.NewLine +
      //                 BreakMessageProvider.I.TimeOfLastBreak;
      //_notifyIcon.Text = message;
      _notifyIcon.Text = "TODO";
    }
    #endregion Non-Public Methods --------------------------------------------------------------------------------
  }
}
