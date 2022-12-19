using ElectrodeListSimplifier.Library.Exceptions;
using ElectrodeListSimplifier.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElectrodeListSimplifier.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SimplifyButton_Click(object sender, RoutedEventArgs e)
        {

            var electrodes = InputTextBox.Text.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                var x = electrodes.ToList().ToSimplifiedString();
                ResultTextBox.Text = x;
            }
            catch(ElectrodeNameFormatException ex)
            {
                MessageBox.Show(ex.UserMessage, "Wrong format", MessageBoxButton.OK);
            }
            catch (Exception )
            {
                MessageBox.Show("Unexpected error has been occured", "Exception", MessageBoxButton.OK);
            }
        }
    }
}
