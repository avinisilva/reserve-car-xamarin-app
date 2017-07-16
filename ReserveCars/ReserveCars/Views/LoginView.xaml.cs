using Xamarin.Forms;

namespace ReserveCars.Views
{
	public partial class LoginView : ContentPage
	{
		public LoginView()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<LoginException>(this, "LoginError", async (exception) => {
                await DisplayAlert("Error in Login", exception.Message, "ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<LoginException>(this, "LoginError");
        }
    }
}