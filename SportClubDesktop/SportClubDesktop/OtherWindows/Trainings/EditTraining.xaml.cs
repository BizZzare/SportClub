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
    /// Interaction logic for EditTraining.xaml
    /// </summary>
    public partial class EditTraining : Window
    {
        private Training _training { get; set; }
        private static readonly Regex _regex = new Regex("[^0-9.]+"); //regex that matches disallowed text
        public List<Member> Members { get; set; }
        public List<Trainer> Trainers { get; set; }

        public EditTraining()
        {
            InitializeComponent();
        }

        public EditTraining(Training training)
        {
            InitializeComponent();

            _training = training;

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

            lstMembers.SelectedIndex = Members.FindIndex(x => x.id_gkey == _training.fkey_member);
            lstTrainers.SelectedIndex = Trainers.FindIndex(x => x.id_gkey == _training.fkey_trainer);

            var hours = new List<int>();
            var minutes = new List<int>();

            for (int i = 0; i < 24; i++)
                hours.Add(i);
            for (int i = 0; i < 60; i++)
                minutes.Add(i);

            cbHours.ItemsSource = hours;
            cbMinutes.ItemsSource = minutes;

            cbHours.SelectedIndex = hours.FindIndex(x => x == _training.date.Hour);
            cbMinutes.SelectedIndex = minutes.FindIndex(x => x == _training.date.Minute);

            dtDate.SelectedDate = _training.date;

            txtCost.Text = _training.cost.ToString();
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
                var date = dtDate.SelectedDate;

                var timeSpan = new TimeSpan((int)cbHours.SelectedItem, (int)cbMinutes.SelectedItem, 0);
                date = ((DateTime)date).Date + timeSpan;



                var result = db.Trainings.FirstOrDefault(x => x.date == _training.date);
                if(result != null)
                {
                    result.date = (DateTime)date;
                    result.fkey_member = (lstMembers.SelectedItem as Member).id_gkey;
                    result.fkey_trainer = (lstTrainers.SelectedItem as Trainer).id_gkey;
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
    }
}
