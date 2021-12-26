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
            if (Program.questions != null)
            {
                Program.questions.IncrementCounter();

                var textBlock = this.FindControl<TextBlock>("NameLabel");
                textBlock.Text = "Your next word is " + Program.questions.counter;

                if (Program.questions.counter >= 0 && Program.questions.counter < Program.questions.QuestionPairs?.Count)
                {
                    textBlock.Text = Program.questions.QuestionPairs?[Program.questions.counter]?.Question;
                }
            }
        }
    }
}
