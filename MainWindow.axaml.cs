using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaImageButton
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ImageButton_Click(object? sender, RoutedEventArgs e)
        {
            btnImage.IsChecked = !btnImage.IsChecked;
        }

        private void btnTest_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            btnImage.IsDisabled = !btnImage.IsDisabled;
        }
    }
}