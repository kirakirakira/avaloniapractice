using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Newtonsoft.Json;
using System.IO;

namespace MyApp
{
    class Program
    {
        public static Questions? questions { get; set; }

        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            questions = JsonConvert.DeserializeObject<Questions>
                (File.ReadAllText("questions.json"));

            Console.WriteLine(questions?.Version);
            Console.WriteLine(questions?.QuestionPairs?[0]?.Question);

            BuildAvaloniaApp()
              .StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
    }
}
