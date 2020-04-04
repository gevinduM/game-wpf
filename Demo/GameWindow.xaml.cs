using System.Collections.Generic;
using System.Windows;
using TrueOrFalse;

namespace Demo
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private readonly List<Statement> _statements;
        private int _counter = 0;
        private int _score = 0;

        private Statement CurrentStatement => _statements[_counter];

        public GameWindow(List<Statement> statements)
        {
            InitializeComponent();
            if (statements == null || statements.Count < 3) 
            {
                MessageBox.Show("Some text", "Some title", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }

            _statements = statements;
            NumberOfStatements.Text = _statements.Count.ToString();

            Loaded += (sender, args) => ShowNext();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void False_Click(object sender, RoutedEventArgs e)
        {
            ProcessAnswer(false);
        }

        private void True_Click(object sender, RoutedEventArgs e)
        {
            ProcessAnswer(true);
        }
        private void ShowNext()
        {
            
                StatementText.Text = _statements[_counter].Text;
                StatementNumber.Text = (_counter + 1).ToString();
            
        }

        private bool EndOfGame()
        {
            return _counter == _statements.Count;
        }
        private string GetMessage()
        {
            double result = (double)_score * 100 / _statements.Count;
            string message = result > 70 ? "Win" : "Lost";
            return message;
        }
        private void ProcessAnswer(bool answer)
        {
            bool isCorrect = answer == CurrentStatement.IsTrue;
            if (isCorrect)
            {
                _score++;
                Score.Text = _score.ToString();
            }

            _counter++;

            if (EndOfGame())
            {
                MessageBox.Show(GetMessage(), "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                ShowNext();
            }
        }
    }
}
