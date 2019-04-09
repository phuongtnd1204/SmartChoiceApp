using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartChoiceApp.ViewModels
{
    public class ReviewPageViewModel : ViewModelBase
    {
        #region Properties
        Database.Database database { get; set; }
        private double _starNumber;
        public double StarNumber
        {
            get => _starNumber;
            set => SetProperty(ref _starNumber, value);
        }

        private double _reiew;
        public double Reiew
        {
            get => _reiew;
            set => SetProperty(ref _reiew, value);
        }

        public ICommand AddReviewCommand { get; set; }

        public List<string> starList { get; set; }
        #endregion
        public ReviewPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            database = new Database.Database();
            AddReviewCommand = new Command(AddReviewAction);
            Init();
        }

        private void Init()
        {
            starList = new List<string> { "1", "2", "3", "4", "5" };
            StarNumber = 0;
        }

        private void AddReviewAction()
        {
            //database.AddReview();
        }
    }
}
