using ElectrodeListSimplifier.Library.Exceptions;
using ElectrodeListSimplifier.Library.Extensions;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ElectrodeListSimplifier.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool inputFirstClick = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SimplifyButton_Click(object sender, RoutedEventArgs e)
        {

            var electrodes = InputTextBox.Text.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                ResultTextBox.Text = electrodes.ToElectrodeList().ToSimplifiedString();
            }
            catch(ElectrodeNameFormatException ex)
            {
                MessageBox.Show(ex.UserMessage, "Wrong format", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error has been occured", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InputTextBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            InputTextBox.Text = string.Empty;
        }

        private void InputTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (inputFirstClick)
            {
                InputTextBox.Text = string.Empty;
                inputFirstClick = false;
            }
        }
    }
}
