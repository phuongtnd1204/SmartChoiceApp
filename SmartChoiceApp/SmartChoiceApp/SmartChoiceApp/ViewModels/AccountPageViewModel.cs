using Prism.Navigation;
using Prism.Services;
using SmartChoiceApp.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartChoiceApp.ViewModels
{
    public class AccountPageViewModel : ViewModelBase
    {
        #region Properties
        private Database.Database database { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public bool _isWaiting = false;
        public bool IsWaiting
        {
            get => _isWaiting;
            set => SetProperty(ref _isWaiting, value);
        }
        public User _userInfo;
        public User UserInfo
        {
            get => _userInfo;
            set => SetProperty(ref _userInfo, value);
        }
        INavigationService navigation;
        IPageDialogService dialog;
        #endregion
        public AccountPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            database = new Database.Database();
            SaveCommand = new Command(SaveAction);
            LogoutCommand = new Command(LogoutAction);
            navigation = navigationService;
            dialog = pageDialogService;
            ReceiveData();
        }

        private void ReceiveData()
        {
            _userInfo = App.mainUser;
        }

        private async void SaveAction()
        {
            IsWaiting = true;
            if(await database.UpdateUser(_userInfo))
            {
                IsWaiting = false;
                await dialog.DisplayAlertAsync("Thông báo", "Cập nhật thành công", "OK");
            }
            else
            {
                IsWaiting = false; ;
                await dialog.DisplayAlertAsync("Thông báo", "Lỗi cập nhật, thử lại!", "OK");
            }
        }
        private void LogoutAction()
        {
            App.mainUser = null;
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
