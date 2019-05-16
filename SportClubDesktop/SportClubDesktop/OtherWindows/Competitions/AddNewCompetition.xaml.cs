using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SportClubDesktop.OtherWindows.Competitions
{
    /// <summary>
    /// Interaction logic for AddNewCompetition.xaml
    /// </summary>
    public partial class AddNewCompetition : Window
    {
        private static readonly Regex _regex = new Regex("[^0-9.]+"); //regex that matches disallowed text

        public AddNewCompetition()
        {
            InitializeComponent();
        }

       
        private void TxtCost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new SportClubEntities())
            {
                var competition = new Competition() { date = dtDate.SelectedDate, cost = Convert.ToDecimal(txtCost.Text)};
                db.Competitions.Add(competition);
                db.SaveChanges();
                Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtCost.Text = "0.0";
            btnSave.IsEnabled = false;
        }

        private void DtDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            checkBtnSaveAvailability();
        }

        private void TxtCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkBtnSaveAvailability();
        }

        private void checkBtnSaveAvailability()
        {
            if (dtDate.SelectedDate != null && String.IsNullOrEmpty(txtCost.Text))
                btnSave.IsEnabled = true;
        }
    }
}
