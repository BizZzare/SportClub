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
    /// Interaction logic for EditCompetition.xaml
    /// </summary>
    public partial class EditCompetition : Window
    {
        private Competition _competition { get; set; }
        private static readonly Regex _regex = new Regex("[^0-9.]+"); //regex that matches disallowed text

        public EditCompetition()
        {
            InitializeComponent();
        }

        public EditCompetition(Competition competition)
        {
            InitializeComponent();

            _competition = competition;
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
                var result = db.Competitions.FirstOrDefault(x => x.gkey == _competition.gkey);
                if (result != null)
                {
                    result.date = dtDate.SelectedDate;
                    result.cost = Convert.ToDecimal(txtCost.Text);

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The problem with editing occured");
                    }
                    Close();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dtDate.SelectedDate = _competition.date;
            txtCost.Text = _competition.cost.ToString();
        }
    }
}
