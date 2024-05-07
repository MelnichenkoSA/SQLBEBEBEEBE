using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using SQLBEBEBEEBE.Model;
using SQLBEBEBEEBE.View;

namespace SQLBEBEBEEBE.ViewModel
{
    internal class MainViewModel
    {
        BDContext db = new BDContext();
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;
        public ObservableCollection<User> Users { get; set; }
        public MainViewModel()
        {
            db.Database.EnsureCreated();
            db.Users.Load();
            Users = db.Users.Local.ToObservableCollection();
        }
        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      UserWindow userWindow = new UserWindow(new User());
                      if (userWindow.ShowDialog() == true)
                      {
                          User user = userWindow.User;
                          db.Users.Add(user);
                          db.SaveChanges();
                      }
                  }));
            }
        }
        // команда редактирования
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      User user = selectedItem as User;
                      if (user == null) return;

                      User vm = new User
                      {
                          UserSurname = user.UserSurname,
                          UserName = user.UserName,
                          UserPatronymic = user.UserPatronymic,
                          UserLogin = user.UserLogin,
                          UserPassword = user.UserPassword
                      };
                      UserWindow userWindow = new UserWindow(vm);


                      if (userWindow.ShowDialog() == true)
                      {
                          user.UserSurname = userWindow.User.UserSurname;
                          user.UserName = userWindow.User.UserName;
                          user.UserPatronymic = userWindow.User.UserPatronymic;
                          user.UserLogin = userWindow.User.UserLogin;
                          user.UserPassword = userWindow.User.UserPassword;
                          db.Entry(user).State = EntityState.Modified;
                          db.SaveChanges();
                      }
                  }));
            }
        }
        // команда удаления
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      User user = selectedItem as User;
                      if (user == null) return;
                      db.Users.Remove(user);
                      db.SaveChanges();
                  }));
            }
        }
    }

}

