﻿using System;
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
using TimeTracker.UI.Models;
using TimeTracker.UI.Utils;
using TimeTracker.UI.ViewModels;

namespace TimeTracker.UI.Pages
{
   /// <summary>
   /// Interaction logic for ucLoginView.xaml
   /// </summary>
   public partial class ucLoginView : UserControl
   {
      public event EventHandler<LoginEventArgs> OnLoginSuccess;

      public ucLoginView()
      {
         InitializeComponent();

         PreviewKeyUp += UcLoginView_PreviewKeyUp;

         LoginBtn.Click += LoginBtn_Click;
      }

      private void UcLoginView_PreviewKeyUp(object sender, KeyEventArgs e)
      {
         if (e.Key == Key.Enter)
         {
            LoginSubmit();
         }
      }

      private void LoginBtn_Click(object sender, RoutedEventArgs e)
      {
         LoginSubmit();
      }

      private async void LoginSubmit()
      {
         LoginVM loginVM = DataContext as LoginVM;
         try
         {
            loginVM.isLoading = true;

            loginVM.password = txtPassword.Password;

            if (string.IsNullOrEmpty(loginVM.user) || string.IsNullOrEmpty(loginVM.password))
            {
               MessageBox.Show("Enter credentials!");
               return;
            }

            AppWebClient.Instance.Address = SettingsLoader<AppConfig>.Instance.Data?.webapi_connection_config?.baseaddress;
            await AppWebClient.Instance.Login(loginVM.user, loginVM.password);
            if (AppWebClient.Instance.GetLoggedUserData() != null)
            {
               OnLoginSuccess.Invoke(this, new LoginEventArgs { });
            }
         }
         catch (Exception ex)
         {
            ex.ShowException();
         }
         finally
         {
            loginVM.isLoading = false;
         }
      }
   }
}
