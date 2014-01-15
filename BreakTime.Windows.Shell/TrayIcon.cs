using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BreakTime.Windows.Shell
{
  /// <summary>
  /// Encapsulates the system tray icon.
  /// </summary>
  public class TrayIcon : IDisposable
  {
    #region Init
    private readonly NotifyIcon _notifyIcon;
    private bool _isDisposed;

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
      if (_isDisposed) throw new ObjectDisposedException("_notifyIcon");
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
      if (!_isDisposed)
      {
        if (isDisposing)
          _notifyIcon.Dispose();

        _isDisposed = true;
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

      return notifyIcon;
    }
    #endregion Non-Public Methods --------------------------------------------------------------------------------
  }
}
