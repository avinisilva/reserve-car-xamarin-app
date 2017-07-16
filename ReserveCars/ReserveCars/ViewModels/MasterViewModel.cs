using ReserveCars.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace ReserveCars.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        public string Name
        {
            get { return this.user.Name; }
            set { this.user.Name = value; }
        }

        public string Phone
        {
            get { return this.user.Phone; }
            set { this.user.Phone = value; }
        }

        public string Email
        {
            get { return this.user.Email; }
            set { this.user.Email = value; }
        }

        private bool editing = false;

        public bool Editing
        {
            get { return editing; }
            private set
            {
                editing = value;
                OnPropertyChanged();
            }
        }

        private readonly User user;

        public ICommand PerfilEditCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        public MasterViewModel(User user)
        {
            this.user = user;

            PerfilEditCommand = new Command(() => {
                MessagingCenter.Send<User>(user, "PerfilEdit");
            });

            SaveCommand = new Command(() => {
                this.Editing = false;
                MessagingCenter.Send<User>(user, "PerfilSaved");
            });

            EditCommand = new Command(() => {
                this.Editing = true;
                MessagingCenter.Send<User>(user, "PerfilEdited");
            });
        }
    }
}
