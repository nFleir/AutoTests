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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private int CaptchaCounter = 1;
        public AuthPage()
        {
            InitializeComponent();
        }

        private void login_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void login_box_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (login_box.Text == "Логин или почта")
            {
                login_box.Clear();
            }
        }

        private string get_captcha()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
            string answer = "";
            Random rnd = new Random();
            for (int i = 0; i < 5;i++)
            {
                answer += chars[rnd.Next(0, chars.Length)];
            }
            return answer;
        }
        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            if (CaptchaCounter >= 3)
            {
                captcha_text.Text = get_captcha();
                captcha_text.Visibility = Visibility.Visible;
                captcha_box.Visibility = Visibility.Visible;
                login_btn.Visibility = Visibility.Hidden;
                captcha_btn.Visibility = Visibility.Visible;
                MessageBox.Show("Слишком много неверных попыток!\nПройдите капчу.");
            }
            else
            {
                Auth(login_box.Text, password_box.Password);
            }
            login_box.Clear();
            password_box.Clear();
        }
        public bool Auth(string login, string password, string captcha = "")
        {
            if (!string.IsNullOrEmpty(captcha))
            {
                if (captcha != captcha_text.Text)
                {
                    MessageBox.Show("Неверная капча!");
                    captcha_box.Clear();
                    return false;
                }
                else if (string.IsNullOrEmpty(captcha) && captcha_box.Text == "Введите капчу")
                {
                    MessageBox.Show("Введите капчу!");
                    return false;
                }
            }    
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return false;
            }
            using (var db = new Entities())
            {
                var user = db.User
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == login && u.Password == password);
                if (user == null)
                {
                    MessageBox.Show("Пользователь с таким логином или паролем не найден!");
                    CaptchaCounter++;
                    return false;
                }
                else if (user.Role != "Удален")
                {
                    MessageBox.Show($"Здравствуйте,{user.Role} {user.FIO.Split('*')[0]}");
                    return true;
                }
                else
                {
                    MessageBox.Show("Вход не выполнен, пользователь удален.");
                    return false;
                }
            }
        }
        private void captcha_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void captcha_box_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (captcha_box.Text == "Введите капчу")
            {
                captcha_box.Clear();
            }
        }

        private void captcha_btn_Click(object sender, RoutedEventArgs e)
        {
            if (!Auth(login_box.Text, password_box.Password, captcha_box.Text))
            {
                captcha_text.Text = get_captcha();
            }
            else
            {
                captcha_box.Clear();
            }
            login_box.Clear();
            password_box.Clear();
        }



        private void registration_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri("/RegPage.xaml", UriKind.Relative));

        }
    }
}
