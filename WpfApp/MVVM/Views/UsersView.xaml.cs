using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp.MVVM.Models;
using WpfApp.MVVM.ViewModels;
using WpfApp.Services;

namespace WpfApp.MVVM.Views
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        private readonly FileService fileService;
        public ObservableCollection<UserModel> users;
        UsersViewModel testc;
        UpdateUserViewModel updateUser;
        //public UserModel UserDetails { get; set; } = null!;
        public UsersView()
        {
            InitializeComponent();
            fileService = new FileService();
            users = fileService.Users();

            testc = new UsersViewModel();
            updateUser= new UpdateUserViewModel();
            DataContext = testc;

            MyListView.ItemsSource = users;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserModel selectedItem = (UserModel)MyListView.SelectedItem;
            //MessageBox.Show(selectedItem.Id.ToString());

            var result = users.FirstOrDefault(x => x.Id == selectedItem.Id);
            if (result != null)
            {
                editBtn.Visibility = Visibility.Visible;
                deleteBtn.Visibility = Visibility.Visible;
            }
            //UserDetails = result!;
            testc.SelectedUser(result!);
            updateUser.SelectedUser(result!);
        }
    }
}
