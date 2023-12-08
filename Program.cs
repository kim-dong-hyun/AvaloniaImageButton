using Avalonia;
using Avalonia.Media;
using System;
using System.Runtime.InteropServices;

namespace AvaloniaImageButton
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return AppBuilder.Configure<App>()
                    .UsePlatformDetect()
                    .WithInterFont()
                    .LogToTrace();
            }
            else
            {
                return AppBuilder.Configure<App>()
                    .UsePlatformDetect()
                    .WithInterFont()
                    .LogToTrace()
                    .With(new FontManagerOptions
                    {
                        DefaultFamilyName = "Arial",
                        FontFallbacks = new[]
                        {
                            new FontFallback
                            {
                                FontFamily = new FontFamily("Arial")
                            }
                        }
                    });
            }
        }
    }
}