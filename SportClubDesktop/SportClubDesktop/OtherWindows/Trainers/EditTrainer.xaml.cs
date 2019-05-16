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
    /// Interaction logic for EditTrainer.xaml
    /// </summary>
    public partial class EditTrainer : Window
    {
        private Trainer _trainer { get; set; }

        public EditTrainer()
        {
            InitializeComponent();
        }

        public EditTrainer(Trainer trainer)
        {
            InitializeComponent();

            _trainer = trainer;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtFullName.Text = _trainer.fio;
            txtPhone.Text = _trainer.telephone;
            txtAddress.Text = _trainer.adress;
            txtCategory.Text = _trainer.category;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new SportClubEntities())
            {
                var currentTrainer = db.Trainers.FirstOrDefault(x => x.id_gkey == _trainer.id_gkey);
                if(currentTrainer != null)
                {
                    currentTrainer.fio = txtFullName.Text;
                    currentTrainer.telephone = txtPhone.Text;
                    currentTrainer.adress = txtAddress.Text;
                    currentTrainer.category = txtCategory.Text;
                    db.SaveChanges();
                    Close();
                }
            }
        }
    }
}
