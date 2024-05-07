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
        RelayCommand autorizeCommand;
        public ObservableCollection<User> Users { get; set; }
        public MainViewModel()
        {
            db.Database.EnsureCreated();
            db.Users.Load();
            Users = db.Users.Local.ToObservableCollection();
        }
        public RelayCommand AutorizeCommand
        {
            get
            {
                return autorizeCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      Autorize autorizeWindow = new Autorize();
                      if (autorizeWindow.ShowDialog() == true)
                      {
                          foreach(User user in db.Users)
                          {
                              if(autorizeWindow.Login==user.UserLogin)
                              {
                                  if(autorizeWindow.Password==user.UserPassword) 
                                  { 
                                      MainWindow mainWindow = new MainWindow();
                                      mainWindow.Show();
                                  }
                              }
                          }
                      }
                  }));
            }
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

