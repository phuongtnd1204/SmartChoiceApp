using Prism.Navigation;
using SmartChoiceApp.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartChoiceApp.ViewModels
{
    public class AccountPageViewModel : ViewModelBase
    {
        #region Properties
        public ICommand SaveCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        INavigationService navigation;
        #endregion
        public AccountPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            SaveCommand = new Command(SaveAction);
            LogoutCommand = new Command(LogoutAction);
            navigation = navigationService;
        }

        private async void SaveAction()
        {
        }
        private void LogoutAction()
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
