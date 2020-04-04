using System.Windows;
using System.Windows.Controls;
using TrueOrFalse;
using Microsoft.Win32;
using System.Reflection;


namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Persistence _trueFalse = new Persistence();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, args) => { SetCurrentState(1); };


        }

        private void SetCurrentState(int index)
        {
            //if the selected index is on the databse set value to the UI elements
            //otherwise set default values, empty and false
            if (_trueFalse.Exists(index))
            {
                StatementText.Text = _trueFalse[index].Text;
                TrueFalseMark.IsChecked = _trueFalse[index].IsTrue;
            }
            else
            {
                StatementText.Text = "";
                TrueFalseMark.IsChecked = false;
            }

            UpdateAddButtonState(index);
            SaveStatement.IsEnabled = !IsStatementEmpty() && _trueFalse.Exists(index);
            RemoveStatement.IsEnabled = _trueFalse.Exists(index);

        }
        //Enable the AddStatement btn if the statement is not empty and value of the selected index is not in the databse
        private void UpdateAddButtonState(int index)
        {
            
            AddStatement.IsEnabled = !IsStatementEmpty() && !_trueFalse.Exists(index);
        }
        private bool IsStatementEmpty()
        {
            return StatementText.Text == string.Empty;
        }
        private int GetCurrentIndex()
        {
            return (int)(StatementNumber.Value == 0 ? 0 : StatementNumber.Value - 1);
        }

        private void NewDb_Click(object sender, RoutedEventArgs e)
        {
            //use windows forms dialog since wpf dosent have such dialog
            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == true)
            {
                _trueFalse = new Persistence();
                _trueFalse.SetFilePath(sfd.FileName);
                _trueFalse.Save();

                StatementNumber.Value = 1;
                StatementText.Text = string.Empty;
            }

        }

        private void OpenDb_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                InitialDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            };
            if (ofd.ShowDialog() == true)
            {
                _trueFalse = new Persistence();
                _trueFalse.SetFilePath(ofd.FileName);
                _trueFalse.Load();
                
            }

            //This will call the StatementNumber_ValueChanged()
            StatementNumber.Value = 1;

        }

        private void SaveDB_Click(object sender, RoutedEventArgs e)
        {
            
            _trueFalse.SetFilePath("database.xml");
            _trueFalse.Save();
        }

        private void DaveAsDb_Click(object sender, RoutedEventArgs e)
        {

            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == true)
            {
                _trueFalse.SetFilePath(sfd.FileName);
                _trueFalse.Save();
            }

        }

        private void SartGame_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gamewin = new GameWindow(_trueFalse.Statements);
            gamewin.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(StatementText.Text);
            StatementText.Text = string.Empty;
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(StatementText.Text);

        }

        private void Past_Click(object sender, RoutedEventArgs e)
        {
            StatementText.Text = Clipboard.GetText();

        }

        private void AddStatement_Click(object sender, RoutedEventArgs e)
        {

            _trueFalse.Add(GetCurrentStatementState());
            StatementNumber.Value++;

        }

        private void SaveStatement_Click(object sender, RoutedEventArgs e)
        {

            UpdateCurrentStatement();
            StatementNumber.Value++;
        }

        private void RemoveStatement_Click(object sender, RoutedEventArgs e)
        {

            int currentIndex = GetCurrentIndex();
            if (_trueFalse.Exists(currentIndex))
            {
                _trueFalse.Remove(currentIndex);

                if (StatementNumber.Value > 1)
                    StatementNumber.Value--;
                else
                    SetCurrentState(1);
            }

        }

        //set the new values from the database when StatementNumber has changed
        //UI value is start from one, list start from 0
        private void StatementNumber_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (StatementText == null)
                return;

            SetCurrentState(GetCurrentIndex());

        }

        private void TrueFalseMark_Click(object sender, RoutedEventArgs e)
        {
            UpdateCurrentStatement();
        }

        private void StatementText_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAddButtonState(GetCurrentIndex());
        }

        private Statement GetCurrentStatementState()
        {
            return new Statement(StatementText.Text, TrueFalseMark.IsChecked.GetValueOrDefault());
        }

        private void UpdateCurrentStatement()
        {
            if (GetCurrentIndex() < _trueFalse.Count) 
                _trueFalse.Change(GetCurrentIndex(), GetCurrentStatementState());
        }


    }
}
