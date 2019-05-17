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
using System.Windows.Shapes;

namespace SportClubDesktop.OtherWindows.Trainers
{
    /// <summary>
    /// Interaction logic for TrainerSchedule.xaml
    /// </summary>
    public partial class TrainerSchedule : Window
    {
        private Trainer _trainer;
        public TrainerSchedule()
        {
            InitializeComponent();
        }

        public TrainerSchedule(Trainer trainer)
        {
            InitializeComponent();

            _trainer = trainer;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblTrainerName.Content = _trainer.fio;

            using (var db = new SportClubEntities())
            {
                lstTrainings.ItemsSource = db.Trainings.Where(x => x.fkey_trainer == _trainer.id_gkey).OrderBy(x => x.date).ToList();
            }
        }
    }
}
