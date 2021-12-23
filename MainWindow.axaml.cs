using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using NetCoreAudio;


namespace MyApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

        }

        public void GreetButton_Click(object sender, RoutedEventArgs e)
        {
            var player = new Player();

            var nameControl = this.FindControl<TextBox>("NameTextBox");
            var messageControl = this.FindControl<TextBlock>("MessageLabel");

            messageControl.Text = $"Hello {nameControl.Text} !!!";
            player.Play("burp_x.wav");
        }

        public void Next(object sender, RoutedEventArgs e)
        {
            // Program.questions.IncrementCounter();

            var textBlock = this.FindControl<TextBlock>("NameLabel");
            textBlock.Text = "Your next word is";


        }
    }
}
