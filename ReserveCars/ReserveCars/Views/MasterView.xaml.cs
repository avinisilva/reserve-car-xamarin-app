using ReserveCars.Models;
using ReserveCars.ViewModels;

using Xamarin.Forms;

namespace ReserveCars.Views
{
    public partial class MasterView : TabbedPage
    {
        public ListView ListView;

        public MasterView(User user)
        {
            InitializeComponent();

            this.BindingContext = new MasterViewModel(user);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.Subscriber();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.Unsubscriber();
           
        }

        private void Subscriber()
        {
            MessagingCenter.Subscribe<User>(this, "PerfilEdit", (user) => {
                this.CurrentPage = this.Children[1];
            });

            MessagingCenter.Subscribe<User>(this, "PerfilSaved", (user) => {
                this.CurrentPage = this.Children[0];
            });
        }

        private void Unsubscriber()
        {
            MessagingCenter.Unsubscribe<User>(this, "PerfilEdit");
            MessagingCenter.Unsubscribe<User>(this, "PerfilSaved");
        }
    }
}