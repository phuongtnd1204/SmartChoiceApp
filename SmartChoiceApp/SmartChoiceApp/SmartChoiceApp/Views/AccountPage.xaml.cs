using Xamarin.Forms;

namespace SmartChoiceApp.Views
{
    public partial class AccountPage : ContentPage
    {
        static bool isOpen = false;
        public AccountPage()
        {
            InitializeComponent();
        }

        private void ChangePassword_Click(object sender, System.EventArgs e)
        {
            if(isOpen)
            {
                PassWordLayout.IsVisible = false;
                isOpen = false;
            }
            else
            {
                PassWordLayout.IsVisible = true;
                isOpen = true;
            }
        }
    }
}
