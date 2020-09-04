using System.Windows;

namespace RestoreAppPositon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (Settings.Default.HasStartupPosition)
            {
                var startupPos = Settings.Default.StartupPosition;
                Left = startupPos.X;
                Top = startupPos.Y;
            }
            InitializeComponent();
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveWindowPosition();
        }

        private void SaveWindowPosition()
        {
            try
            {
                Settings.Default.StartupPosition = new Point(Left, Top);
                Settings.Default.HasStartupPosition = true;
                Settings.Default.Save();
            }
            catch
            {
            }
        }
    }
}
