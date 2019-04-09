using Prism.Navigation;
using Rg.Plugins.Popup.Services;
using SmartChoiceApp.Models;
using SmartChoiceApp.Views;
using System.Collections.ObjectModel;

namespace SmartChoiceApp.ViewModels
{
    public class PestilentInsectDetailPageViewModel : ViewModelBase
    {
        #region Properties
        public ObservableCollection<PestilentInsect> _insects;
        public ObservableCollection<PestilentInsect> Insects
        {
            get => _insects;
            set => SetProperty(ref _insects, value);
        }
        public int PestilentInsectID { get; set; }

        public Database.Database database;
        #endregion

        #region Constructor
        public PestilentInsectDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            database = new Database.Database();
            Insects = new ObservableCollection<PestilentInsect>();
        }
        #endregion

        #region Override & Init
        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            PestilentInsectID = parameters.GetValue<int>("ID");
            Init();
        }

        private async void Init()
        {
            await PopupNavigation.Instance.PushAsync(new ErrorPopup(), true);
            Insects = new ObservableCollection<PestilentInsect>(await database.GetPestilentInsect(PestilentInsectID));
            await PopupNavigation.Instance.PopAsync();
        }
        #endregion
    }
}
