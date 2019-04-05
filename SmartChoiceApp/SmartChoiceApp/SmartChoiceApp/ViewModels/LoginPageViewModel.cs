using Prism.Navigation;
using SmartChoiceApp.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartChoiceApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region
        public ICommand LoginCommand { get; set; }
        public ICommand SignUpCommand { get; set; }
        INavigationService navigation;
        #endregion
        public LoginPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            LoginCommand = new Command(Login);
            SignUpCommand = new Command(SignUp);
            navigation = navigationService;
        }
        private void Login()
        {
            Application.Current.MainPage = new NavigationPage(new MainTabbedPage());
        }

        private async void SignUp()
        {
            await navigation.NavigateAsync("SignUpPage");
        }
    }
}
