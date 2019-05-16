using SportClubDesktop.OtherWindows.Competitions;
using SportClubDesktop.OtherWindows.Members;
using SportClubDesktop.OtherWindows.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SportClubDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Common
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new SportClubEntities())
            {
                lstTrainers.ItemsSource = db.Trainers.ToList();
                lstCompetitions.ItemsSource = db.Competitions.OrderBy(x=>x.date).ToList();
                lstMembers.ItemsSource = db.Members.ToList();
                lstTrainings.ItemsSource = db.Trainings.ToList();

            }

            var hours = new List<int>();
            var minutes = new List<int>();

            for (int i = 0; i < 24; i++)
                hours.Add(i);
            for (int i = 0; i < 60; i++)
                minutes.Add(i);

            cbFindHours.ItemsSource = hours;
            cbFindMinutes.ItemsSource = minutes;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            btnTrainerDelete.IsEnabled = lstTrainers.SelectedItem != null;
            btnTrainerEdit.IsEnabled = lstTrainers.SelectedItem != null;

            btnCompetitionDelete.IsEnabled = lstCompetitions.SelectedItem != null;
            btnCompetitionEdit.IsEnabled = lstCompetitions.SelectedItem != null;

            btnMemberDelete.IsEnabled = lstMembers.SelectedItem != null;
            btnMemberEdit.IsEnabled = lstMembers.SelectedItem != null;

            btnTrainingDelete.IsEnabled = lstTrainings.SelectedItem != null;
            btnTrainingEdit.IsEnabled = lstTrainings.SelectedItem != null;
        }

        #endregion

        #region Trainers
        private void TxtFindTrainer_TextChanged(object sender, TextChangedEventArgs e)
        {
            var name = txtFindTrainer.Text.ToLower();
            using (var db = new SportClubEntities())
            {
                lstTrainers.ItemsSource = db.Trainers.Where(x => x.fio.ToLower().Contains(name)).ToList();
            }
        }

        private void LstTrainers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnTrainerDelete.IsEnabled = lstTrainers.SelectedItem != null;
            btnTrainerEdit.IsEnabled = lstTrainers.SelectedItem != null;
        }
        private void BtnAddNewTrainer_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddNewTrainer();
            window.ShowDialog();
            updateTrainersList();
        }
       
        private void BtnTrainerEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedTrainer = lstTrainers.SelectedItem as Trainer;
            if(selectedTrainer != null)
            {
                var window = new EditTrainer(selectedTrainer);
                window.ShowDialog();
                updateTrainersList();
            }
        }

        private void BtnTrainerDelete_Click(object sender, RoutedEventArgs e)
        {
            var trainer = lstTrainers.SelectedItem as Trainer;
            if (trainer != null) {
                var messageBoxResult = MessageBox.Show($"Are you sure you want to delete \'{trainer.fio}\'?", "Delete Confirmation", MessageBoxButton.YesNoCancel);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    using (var db = new SportClubEntities())
                    {
                        var trainerToDelete = db.Trainers.First(x => x.id_gkey == trainer.id_gkey);
                        db.Trainers.Remove(trainerToDelete);
                        db.SaveChanges();
                        updateTrainersList();
                    }
                }
            }
        }

        private void updateTrainersList()
        {
            txtFindTrainer.Text = "";

            using (var db = new SportClubEntities())
            {
                lstTrainers.ItemsSource = db.Trainers.ToList();
            }
        }
        #endregion

        #region Competitions

        private void DtFindCompetition_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new SportClubEntities())
            {
                lstCompetitions.ItemsSource = db.Competitions.Where(x => x.date == dtFindCompetition.SelectedDate).OrderBy(x => x.date).ToList();
            }
        }

        private void LstCompetitions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCompetitionEdit.IsEnabled = lstCompetitions.SelectedItem != null;
            btnCompetitionDelete.IsEnabled = lstCompetitions.SelectedItem != null;
        }

        private void BtnAddNewCompetition_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddNewCompetition();
            window.ShowDialog();
            updateCompetitionsList();
        }

        private void BtnCompetitionEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedCompetition = lstCompetitions.SelectedItem as Competition;
            if (selectedCompetition != null)
            {
                var window = new EditCompetition(selectedCompetition);
                window.ShowDialog();
                updateCompetitionsList();
            }
        }

        private void BtnCompetitionDelete_Click(object sender, RoutedEventArgs e)
        {
            var competition = lstCompetitions.SelectedItem as Competition;
            if (competition != null)
            {
                var messageBoxResult = MessageBox.Show($"Are you sure you want to delete the competition scheduled on {competition}?", "Delete Confirmation", MessageBoxButton.YesNoCancel);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    using (var db = new SportClubEntities())
                    {
                        var competitionToDelete = db.Competitions.First(x => x.gkey == competition.gkey);
                        db.Competitions.Remove(competitionToDelete);
                        db.SaveChanges();
                        updateCompetitionsList();
                    }
                }
            }
        }

        private void BtnFindByDateDiscard_Click(object sender, RoutedEventArgs e)
        {
            updateCompetitionsList();
        }

        private void updateCompetitionsList()
        {
            dtFindCompetition.SelectedDate = null;

            using (var db = new SportClubEntities())
            {
                lstCompetitions.ItemsSource = db.Competitions.OrderBy(x => x.date).ToList();
            }
        }



        #endregion

        #region Members
        private void TxtFindMember_TextChanged(object sender, TextChangedEventArgs e)
        {
            var name = txtFindMember.Text.ToLower();
            using (var db = new SportClubEntities())
            {
                lstMembers.ItemsSource = db.Members.Where(x => x.fio.ToLower().Contains(name)).ToList();
            }
        }

        private void LstMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnMemberDelete.IsEnabled = lstMembers.SelectedItem != null;
            btnMemberEdit.IsEnabled = lstMembers.SelectedItem != null;
        }

        private void BtnAddNewMember_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddNewMember();
            window.ShowDialog();
            updateMembersList();
        }

        private void BtnMemberEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedMember = lstMembers.SelectedItem as Member;
            if (selectedMember != null)
            {
                var window = new EditMember(selectedMember);
                window.ShowDialog();
                updateMembersList();
            }
        }

        private void BtnMemberDelete_Click(object sender, RoutedEventArgs e)
        {
            var member = lstMembers.SelectedItem as Member;
            if (member != null)
            {
                var messageBoxResult = MessageBox.Show($"Are you sure you want to delete \'{member.fio}\'?", "Delete Confirmation", MessageBoxButton.YesNoCancel);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    using (var db = new SportClubEntities())
                    {
                        var memberToDelete = db.Members.First(x => x.id_gkey == member.id_gkey);
                        db.Members.Remove(memberToDelete);
                        db.SaveChanges();
                        updateMembersList();
                    }
                }
            }
        }

        private void updateMembersList()
        {
            txtFindMember.Text = "";

            using (var db = new SportClubEntities())
            {
                lstMembers.ItemsSource = db.Members.ToList();
            }
        }

#endregion
        private void DtFindTraining_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new SportClubEntities())
            {
                var date = dtFindTraining.SelectedDate;
                if (date != null)
                {
                    if(cbFindHours.SelectedItem != null)
                    {
                        var timeSpan = new TimeSpan((int)cbFindHours.SelectedItem, 0, 0);
                        date = ((DateTime)date).Date + timeSpan;
                    }
                    if (cbFindMinutes.SelectedItem != null)
                    {
                        var timeSpan = new TimeSpan(0, (int)cbFindMinutes.SelectedItem, 0);
                        date = ((DateTime)date).Date + timeSpan;
                    }
                    lstTrainings.ItemsSource = db.Trainings.Where(x => x.date == date).OrderBy(x => x.date).ToList();
                }
            }
        }

        private void LstTrainings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnTrainingDelete.IsEnabled = lstTrainings.SelectedItem != null;
            btnTrainingEdit.IsEnabled = lstTrainings.SelectedItem != null;
        }

        private void BtnAddNewTraining_Click(object sender, RoutedEventArgs e)
        {

            updateTrainingsList();
        }

        private void BtnTrainingEdit_Click(object sender, RoutedEventArgs e)
        {

            updateTrainingsList();
        }

        private void BtnTrainingDelete_Click(object sender, RoutedEventArgs e)
        {

            updateTrainingsList();
        }

        private void BtnFindByDateDiscardTraining_Click(object sender, RoutedEventArgs e)
        {
            updateTrainingsList();
        }

        private void updateTrainingsList()
        {
            dtFindTraining.SelectedDate = null;

            cbFindHours.SelectedItem = null;
            cbFindMinutes.SelectedItem = null;

            using (var db = new SportClubEntities())
            {
                lstCompetitions.ItemsSource = db.Trainings.OrderBy(x => x.date).ToList();
            }
        }
    }
}
