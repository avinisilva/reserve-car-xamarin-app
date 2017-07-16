using ReserveCars.Models;
using ReserveCars.Views;
using Xamarin.Forms;

namespace ReserveCars
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<User>(this, "LoginSuccess", 
                (user) => {
                    MainPage = new MasterDetailView(user);
                });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
