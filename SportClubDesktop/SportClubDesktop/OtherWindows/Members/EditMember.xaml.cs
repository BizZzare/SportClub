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

namespace SportClubDesktop.OtherWindows.Members
{
    /// <summary>
    /// Interaction logic for EditMember.xaml
    /// </summary>
    public partial class EditMember : Window
    {
        private Member _member { get; set; }
        public EditMember()
        {
            InitializeComponent();
        }

        public EditMember(Member member)
        {
            InitializeComponent();

            _member = member;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new SportClubEntities())
            {
                var currentMember = db.Members.FirstOrDefault(x => x.id_gkey == _member.id_gkey);
                if (currentMember != null)
                {
                    currentMember.fio = txtFullName.Text;
                    currentMember.telephone = txtPhone.Text;
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
            txtFullName.Text = _member.fio;
            txtPhone.Text = _member.telephone;
        }
    }
}
