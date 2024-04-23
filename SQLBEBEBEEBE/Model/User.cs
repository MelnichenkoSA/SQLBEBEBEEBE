using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SQLBEBEBEEBE.Model
{
    internal class User: INotifyPropertyChanged
    {
        private string UserID { get; set; }
        private string userSurname;
        private string userName;
        private string userPatronymic;
        private string userLogin;
        private string userPassword;
        private int userRole;

        public string UserSurname
        {
            get { return userSurname; }
            set
            {
                userSurname = value;
                OnPropertyChanged("UserSurname");
            }
        }
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }
        public string UserPatronymic
        {
            get { return userPatronymic; }
            set
            {
                userPatronymic = value;
                OnPropertyChanged("UserPatronymic");
            }
        }
        public string UserLogin
        {
            get { return userLogin; }
            set
            {
                userLogin = value;
                OnPropertyChanged("UserLogin");
            }
        }
        public string UserPassword
        {
            get { return userPassword; }
            set
            {
                userPassword = value;
                OnPropertyChanged("UserPassword");
            }
        }
        public int UserRole
        {
            get { return userRole; }
            set
            {
                userRole = value;
                OnPropertyChanged("UserRole");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
