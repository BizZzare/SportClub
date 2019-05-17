using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace SportClubDesktop.OtherWindows.Competitions
{
    /// <summary>
    /// Interaction logic for SignUpMember.xaml
    /// </summary>
    public partial class SignUpMember : Window
    {
        private Competition _competition;
        public SignUpMember()
        {
            InitializeComponent();
        }

        public SignUpMember(Competition competition)
        {
            InitializeComponent();

            _competition = competition;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new SportClubEntities())
            {
                var competition = db.Competitions.FirstOrDefault(x => x.gkey == _competition.gkey);
                var selectedMemberId = (lstMembers.SelectedItem as Member).id_gkey;
                var member = db.Members.FirstOrDefault(x => x.id_gkey == selectedMemberId);
                if (competition != null && member != null)
                {
                    competition.Members.Add(member);
                    
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("The member was signed up successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,"Cannot sign the member up for the competition");
                    }
                    Close();

                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnConfirm.IsEnabled = false;

            using (var db = new SportClubEntities())
            {
                lstMembers.ItemsSource = db.Members.OrderBy(x => x.fio).ToList();
            }

            lblCost.Content = ((decimal)_competition.cost).ToString("C", CultureInfo.CurrentCulture);
            lblDate.Content = _competition.date;
        }

        private void LstMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnConfirm.IsEnabled = lstMembers.SelectedItem != null;
        }
    }
}
