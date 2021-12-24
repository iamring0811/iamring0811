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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserProperty User;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void User_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("31:" + e.PropertyName);
            switch (e.PropertyName)
            {
                case "Name":
                    txtName.Text = User.Name;
                    break;
                case "Age":
                    txtAge.Text = User.Age.ToString();
                    DateTime dt = DateTime.Now;
                    int year = dt.Year - Convert.ToInt32(txtAge.Text) + 1;
                    txtTime.Text = year.ToString();
                    break;
            }
        }
        private void ViewData(UserProperty User)
        {
            txtName.Text = User.Name;
            txtAge.Text = User.Age.ToString();
        }
        private UserProperty GetData()
        {
            UserProperty userProperty = new UserProperty("김형관", 34);
            return userProperty;
        }
        private UserProperty GetData2()
        {
            UserProperty userProperty = new UserProperty("김로사", 43);
            return userProperty;
        }

        private void btnOption_Click(object sender, RoutedEventArgs e)
        {
            User = GetData();
            ViewData(User);
            User.PropertyChanged += User_PropertyChanged;
        }

        private void btnOption2_Click(object sender, RoutedEventArgs e)
        {
            User = GetData2();
            ViewData(User);
            User.PropertyChanged += User_PropertyChanged;
        }

        private void btnBirthday_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(txtAge.Text) != 0)
            {
                DateTime dt = DateTime.Now;
                int year = dt.Year - Convert.ToInt32(txtAge.Text) + 1;
                txtTime.Text = year.ToString();
            }
                
        }

        private void btnPlusAge_Click(object sender, RoutedEventArgs e)
        {
            User.Age++;
        }
    }
}
