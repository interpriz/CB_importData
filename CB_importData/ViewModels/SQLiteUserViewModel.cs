using CB_importData.Models;
using CB_importData.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace CB_importData.ViewModels
{
    public class SQLiteUserViewModel
    {
        UsersRepository db = new UsersRepository();
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        RelayCommand? openCommand;
        RelayCommand? saveCommand;

        IFileService<User> fileService;
        IDialogService dialogService;

        public ObservableCollection<User> Users { get; set; }
        public SQLiteUserViewModel(IDialogService dialogService, IFileService<User> fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            db.Database.EnsureCreated();
            db.Users.Load();
            Users = db.Users.Local.ToObservableCollection();
        }

        // команда сохранения файла
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              fileService.Save(dialogService.FilePath, db.Users.ToList());
                              dialogService.ShowMessage("Файл сохранен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        // команда открытия файла
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {

                              bool validate = false;
                              try
                              {
                                  fileService.Validation(dialogService.FilePath);
                                  validate = true;

                              }
                              catch (XmlSchemaValidationException ex)
                              {
                                  dialogService.ShowMessage($"Произошло исключение:   {ex.Message}\n\r" +
                                  "Документ не прошел проверку достоверности.");
                              }

                              if(validate)
                              {
                                  List<User> users = fileService.Open(dialogService.FilePath);
                                  
                                  db.importData(users);

                                  dialogService.ShowMessage("Файл открыт");
                              }
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
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
                          db.addUser(userWindow.User);
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
                      User? user = selectedItem as User;
                      if (user == null) return;

                      User vm = new User
                      {
                          Id = user.Id,
                          Name = user.Name,
                          Age = user.Age
                      };
                      UserWindow userWindow = new UserWindow(vm);


                      if (userWindow.ShowDialog() == true)
                      {
                          
                          user.Name = userWindow.User.Name;
                          user.Age = userWindow.User.Age;
                          db.updateUser(user);
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
                      User? user = selectedItem as User;
                      if (user == null) return;
                      db.removeUser(user);
                  }));
            }
        }
    }
}
