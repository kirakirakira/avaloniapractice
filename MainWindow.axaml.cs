using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using NetCoreAudio;
using System;


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
            var messageControl = this.FindControl<TextBlock>("NameLabel");

            messageControl.Text = $"Hello {nameControl.Text} !!!";
            player.Play("burp_x.wav");
        }

        public void NextQuestion(object sender, RoutedEventArgs e)
        {
            var scoreText = this.FindControl<TextBlock>("Score");
            scoreText.Text = string.Empty;

            if (Program.questions != null)
            {
                Program.questions.IncrementCounter();

                var textBlock = this.FindControl<TextBlock>("QuestionText");
                textBlock.Text = "Your next word is " + Program.questions.counter;

                if (Program.questions.counter >= 0 && Program.questions.counter < Program.questions.QuestionPairs?.Count)
                {
                    textBlock.Text = Program.questions.QuestionPairs?[Program.questions.counter]?.Question;
                }
            }
        }

        public void Submit(object sender, RoutedEventArgs e)
        {
            var answerText = this.FindControl<TextBox>("AnswerBox");

            var scoreText = this.FindControl<TextBlock>("Score");

            if (Program.questions != null)
            {
                if (Program.questions.counter >= 0 && Program.questions.counter < Program.questions.QuestionPairs?.Count)
                {
                    if (Int16.Parse(answerText.Text) == Program.questions.QuestionPairs?[Program.questions.counter]?.Answer)
                    {
                        scoreText.Text = "You got it correct!";
                    }
                    else
                    {
                        scoreText.Text = "You got it wrong :'(";

                    }
                }
            }
        }
    }
}
