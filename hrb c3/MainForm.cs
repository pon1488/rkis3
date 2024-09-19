using hrb_c3.UsersClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static hrb_c3.UsersClasses.InfoEmailSending;

namespace hrb_c3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            textBoxEmail.Text = "apaoap@internet.ru";
            textBoxName.Text = "Nikol Poleonok";
        }


        private void buttonSend_Click(object sender, EventArgs e)
        {

            //проверка TextBox на наличие значений
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) || 
                string.IsNullOrWhiteSpace(textBoxName.Text) || 
                string.IsNullOrWhiteSpace(textBoxSubject.Text) ||
                string.IsNullOrWhiteSpace(textBoxBody.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
          
            // Ввод данных с формы в объекты ранее созданных классов
            string smtp = "smtp.mail.ru";
            // Необходимо ввести свой mail.ru адрес!!! И своё ФИО
            StringPair fromInfo = new StringPair("apaoap@internet.ru", "Полеонок Николь Дмитриевна"); // Необходимо ввести свой пароль который вывел mail.ru !!!
            string password = "1TBcVHFgyrkCXuKyxuYT";
            StringPair toInfo = new StringPair(textBoxEmail.Text, textBoxName.Text); string subject = textBoxSubject.Text; string body = $"{DateTime.Now} \n" + $"{Dns.GetHostName()} \n" +
            $"{Dns.GetHostAddresses(Dns.GetHostName()).First()} \n" +
            $" {textBoxBody.Text}";
            InfoEmailSending info =
            new InfoEmailSending(smtp, fromInfo, password, toInfo, subject, body); // Отправка данных в виде электронного письма
                                   SendindEmail sendingEmail = new SendindEmail(info); sendingEmail.Send();
                                                                                   //Уведомления для пользователя и очистка всех
                               MessageBox.Show("Письмо отправлено!");
            foreach (TextBox textBox in Controls.OfType<TextBox>()) textBox.Text = "";
        }
    }
}
