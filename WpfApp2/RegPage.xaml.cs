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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
            roles.Items.Add("Администратор");
            roles.Items.Add("Менеджер А");
            roles.Items.Add("Менеджер С");

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SecondFrame.NavigationService.Navigate(new Uri("/AuthPage.xaml", UriKind.Relative));
        }

        private void FIO_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FIO_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FIO.Text == "Введите ФИО")
            {
                FIO.Clear();
            }
        }

        private void loginbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void loginbox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (loginbox.Text == "Введите логин")
            {
                loginbox.Clear();
            }
        }

        private void parolbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void parolbox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (parolbox.Password == "Введите пароль")
            {
                parolbox.Clear();
            }
        }

        private void phonebox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void phonebox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (phonebox.Text == "Введите телефончик")
            {
                phonebox.Clear();
            }
        }

        private void photobox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void photobox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (photobox.Text == "Ссылка на фото")
            {
                photobox.Clear();
            }
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            if (reg(FIO.Text, loginbox.Text, parolbox.Password, MaleButton.IsChecked == true ? true : false, roles.Text, phonebox.Text, photobox.Text))
            {
                SecondFrame.NavigationService.Navigate(new Uri("/AuthPage.xaml", UriKind.Relative));
            }
            loginbox.Clear();
            FIO.Clear();
            parolbox.Clear();
            phonebox.Clear();
            photobox.Clear();
            MaleButton.IsChecked = false;
            FemaleButton.IsChecked = false;
            roles.SelectedItem = null;

        }
        public bool reg(string FIO, string login, string password, bool IsMale, string role, string phone, string photo)
        {
            if (string.IsNullOrEmpty(login) || login == "Введите логин")
            {
                MessageBox.Show("Поле логин не заполнено");
                return false;
            }
            else if (string.IsNullOrEmpty(FIO) || FIO == "Введите ФИО")
            {
                MessageBox.Show("Поле ФИО не заполнено");
                return false;
            }
            else if (string.IsNullOrEmpty(password) || password == "Введите пароль")
            {
                MessageBox.Show("Поле пароль не заполнено");
                return false;
            }
            else if (string.IsNullOrEmpty(photo) || photo == "Ссылка на фото")
            {
                MessageBox.Show("Ссылка на фото отсутствует");
                return false;
            }
            else if (phone.Count(char.IsDigit) != 11)
            {
                MessageBox.Show("Поле телефон не заполнено");
                return false;
            }
            else if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Не выбрана роль");
                return false;
            }
            else if (IsMale == null)
            {
                MessageBox.Show("Не выбран пол");
                return false;
            }

            Entities db = new Entities();
            var user = db.User
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == login);
            if (user != null)
            {
                MessageBox.Show("Такой пользователь уже существует");
                return false;
            }
            User userObject = new User
            {
                FIO = FIO,
                Login = login,
                Password = password,
                Role = role,
                Photo = photo,
                Phone = phone,
                Sex = IsMale == true ? "Мужчина" : "Женщина"

            };
            db.User.Add(userObject);
            db.SaveChanges();
            MessageBox.Show("Пользователь успешно зарегистрирован!");
            return true;
        }

    }
}
