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
    /// Interaction logic for AddNewTrainer.xaml
    /// </summary>
    public partial class AddNewTrainer : Window
    {
        public AddNewTrainer()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new SportClubEntities())
            {
                var trainer = new Trainer() { fio = txtFullName.Text, telephone = txtPhone.Text, adress = txtAddress.Text, category = txtCategory.Text };
                db.Trainers.Add(trainer);
                db.SaveChanges();
                Close();
            }
        }

        private void TxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (
                !String.IsNullOrEmpty(txtFullName.Text) &&
                !String.IsNullOrEmpty(txtPhone.Text) && 
                !String.IsNullOrEmpty(txtAddress.Text) && 
                !String.IsNullOrEmpty(txtCategory.Text)
                )
                btnSave.IsEnabled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnSave.IsEnabled = false;
        }
    }
}
