using Prism.Navigation;
using Rg.Plugins.Popup.Services;
using SmartChoiceApp.Models;
using SmartChoiceApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartChoiceApp.ViewModels
{
    public class ProductPageViewModel : ViewModelBase
    {
        #region Properties
        public bool isLoading { get; set; }
        public Database.Database database { get; set; }
        public int ProductID { get; set; }
        public ICommand ManufacturerDetailCommand { get; set; }
        public ICommand PestilentInsectCommand { get; set; }
        public ICommand ReviewCommand { get; set; }
        INavigationService navigation;
        private ObservableCollection<data> imageSources;
        public ObservableCollection<data> ImageSources
        {
            get => imageSources;
            set => SetProperty(ref imageSources, value);
        }
        private ProductDetail product;
        public ProductDetail Product
        {
            get => product;
            set => SetProperty(ref product, value);
        }

        private ImageSource images;
        public ImageSource Images
        {
            get => images;
            set => SetProperty(ref images, value);
        }

        private string productName;
        public string ProductName
        {
            get => productName;
            set => SetProperty(ref productName, value);
        }

        private int scanTimes;
        public int ScanTimes
        {
            get => scanTimes;
            set => SetProperty(ref scanTimes, value);
        }

        private double averageRating;
        public double AverageRating
        {
            get => averageRating;
            set => SetProperty(ref averageRating, value);
        }

        private string manufacturerName;
        public string ManufacturerName
        {
            get => manufacturerName;
            set => SetProperty(ref manufacturerName, value);
        }

        private ProductInfo productInfo;
        public ProductInfo ProductInfo
        {
            get => productInfo;
            set => SetProperty(ref productInfo, value);
        }

        private ObservableCollection<Review> reviews;
        public ObservableCollection<Review> Reviews
        {
            get => reviews;
            set => SetProperty(ref reviews, value);
        }
        #endregion

        #region Constructor
        public ProductPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            ManufacturerDetailCommand = new Command(ManufacturerDetailAction);
            PestilentInsectCommand = new Command(PestilentInsectAction);
            ReviewCommand = new Command(ReviewAction);
            navigation = navigationService;
            ImageSources = new ObservableCollection<data>();
            Product = new ProductDetail();
            database = new Database.Database();
        }


        private async void Init()
        {
            await PopupNavigation.Instance.PushAsync(new ErrorPopup(), true);
            Product = await database.GetProductDetail(ProductID);
            ProductInfo = Product.infor;
            Reviews = new ObservableCollection<Review>(Product.comments);
            await PopupNavigation.Instance.PopAsync();
        }
        #endregion
        #region Command

        private async void ManufacturerDetailAction()
        {
            NavigationParameters parameter = new NavigationParameters();
            parameter.Add("ID", 1);
            await navigation.NavigateAsync(new System.Uri("ManufacturerDetailPage",UriKind.Relative), parameter);
        }

        private async void PestilentInsectAction()
        {
            await navigation.NavigateAsync("PestilentInsectDetailPage");
        }

        private async void ReviewAction()
        {
            await navigation.NavigateAsync("ReviewPage");
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            ProductID = parameters.GetValue<int>("ID");
            Init();
        }

        #endregion

        #region Function

        #endregion
    }
}
