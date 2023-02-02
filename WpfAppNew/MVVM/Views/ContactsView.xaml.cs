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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppNew.MVVM.Models;
using WpfAppNew.MVVM.ViewModels;
using WpfAppNew.Services;

namespace WpfAppNew.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ContactsView.xaml
    /// </summary>
    public partial class ContactsView : UserControl
    {
        public ContactsView()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ContactModel selectedContact = (ContactModel)lv_MyListView.SelectedItem;
            if (selectedContact != null)
            {
                btn_RemoveBtn.Visibility = Visibility.Visible;
                btn_EditBtn.Visibility = Visibility.Visible;  
                tb_InfoText.Visibility = Visibility.Visible;
            }  
        }
    }
}
