using CB_importData.Models;
using CB_importData.Repositories;
using CB_importData.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Xml.Linq;
using System.Xml.Schema;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CB_importData.ViewModels
{
    class CBViewmodel
    {
        ED807Repository db = new ED807Repository();
        RelayCommand? searchCommand;
        RelayCommand? saveCommand;
        RelayCommand? openCommand;


        IFileService<ED807> fileService;
        IDialogService dialogService;

        public ObservableCollection<ED807> Records { get; set; }
        

        public CBViewmodel(IDialogService dialogService, IFileService<ED807> fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            //db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            db.ED807
                .Include(e => e.bICDirectoryEntry)
                    .ThenInclude(b => b!.participantInfo)
                    .Load();
            Records = db.ED807.Local.ToObservableCollection();
        }

        // команда поиска
        public RelayCommand SearchCommand
        {
            get
            {
                return searchCommand ??
                  (searchCommand = new RelayCommand((bic) =>
                  {
                      // получаем выделенный объект
                      int BIC = 0;
                      try
                      {
                          BIC = Convert.ToInt32(bic);
                      }
                      catch
                      {
                          dialogService.ShowMessage("Неверно введено значение!");
                          return;
                      }
                      
                      

                      List<Accounts> accounts = db.simpleSerch(BIC);
                      
                      AccountsWindow accountsWindow = new AccountsWindow(accounts);

                      accountsWindow.Show();
                  }));
            }
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
                              fileService.Save(dialogService.FilePath, db.ED807.ToList());
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
                          Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                          if (dialogService.OpenFileDialog() == true)
                          {

                              bool validate = false;
                              try
                              {
                                  fileService.Validation(dialogService.FilePath);
                                  validate = true;
                                  dialogService.ShowMessage("Документ прошел проверку достоверности.");

                              }
                              catch (XmlSchemaValidationException ex)
                              {
                                  dialogService.ShowMessage($"Произошло исключение:   {ex.Message}\n\r" +
                                  "Документ не прошел проверку достоверности.");
                              }

                              if (validate)
                              {
                                  List<ED807> records = fileService.Open(dialogService.FilePath);

                                  db.importData(records);

                                  dialogService.ShowMessage("Данные загружены в БД.");
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

    }
}
