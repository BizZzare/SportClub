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

namespace SportClubDesktop.OtherWindows.Trainings
{
    /// <summary>
    /// Interaction logic for AddNewTraining.xaml
    /// </summary>
    public partial class AddNewTraining : Window
    {
        public List<Member> Members { get; set; }
        public List<Trainer> Trainers { get; set; }

        private static readonly Regex _regex = new Regex("[^0-9.]+"); //regex that matches disallowed text

        public AddNewTraining()
        {
            InitializeComponent();

            using (var db = new SportClubEntities())
            {
                Members = db.Members.OrderBy(x => x.fio).ToList();
                Trainers = db.Trainers.OrderBy(x => x.fio).ToList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstMembers.ItemsSource = Members;
            lstTrainers.ItemsSource = Trainers;

            btnSave.IsEnabled = false;

            var hours = new List<int>();
            var minutes = new List<int>();

            for (int i = 0; i < 24; i++)
                hours.Add(i);
            for (int i = 0; i < 60; i++)
                minutes.Add(i);

            cbHours.ItemsSource = hours;
            cbMinutes.ItemsSource = minutes;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
                var date = dtDate.SelectedDate;

                var timeSpan = new TimeSpan((int)cbHours.SelectedItem, (int)cbMinutes.SelectedItem, 0);
                date = ((DateTime)date).Date + timeSpan;


                var training = new Training() {
                    date = (DateTime)date,
                    cost = Convert.ToDecimal(txtCost.Text),
                    fkey_member = (lstMembers.SelectedItem as Member).id_gkey,
                    fkey_trainer = (lstTrainers.SelectedItem as Trainer).id_gkey
                };

                db.Trainings.Add(training);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The problem with adding occured");
                }
                Close();
            }
        }

        private void checkBtnSaveAvailability()
        {
            if (
                dtDate.SelectedDate != null &&
                !String.IsNullOrEmpty(txtCost.Text) &&
                lstTrainers.SelectedItem != null &&
                lstMembers.SelectedItem != null &&
                cbHours.SelectedItem != null &&
                cbMinutes.SelectedItem != null
                )
                btnSave.IsEnabled = true;
        }

        private void DtDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            checkBtnSaveAvailability();
        }

        private void CbHours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkBtnSaveAvailability();
        }

        private void LstMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkBtnSaveAvailability();
        }

        private void TxtCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkBtnSaveAvailability();
        }
    }
}
