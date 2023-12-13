using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

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

        private void btnTest_Click(object? sender, RoutedEventArgs e)
        {
            btnImage.IsDisabled = !btnImage.IsDisabled;
        }

        private void btnTest2_Click(object? sender, RoutedEventArgs e)
        {
            object? resource;
            if (TryGetResource("imageShowDisabled", this.ActualThemeVariant, out resource))
            {
                btnImage.CurrentImage = (IImage)resource;
                //btnImage.UnCheckedImage = (IImage)resource;
            }
        }
    }
}