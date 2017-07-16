using System.Windows.Input;
using Xamarin.Forms;

namespace ReserveCars.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private string username;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged();
                ((Command)LoginCommand).ChangeCanExecute();
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
                ((Command)LoginCommand).ChangeCanExecute();
            }
        }

        public ICommand LoginCommand { get; private set; }

        public LoginViewModel()
        {            
            LoginCommand = new Command(async () => {
                await (new LoginService()).DoLogin(this.Username, this.Password);
            }, () => {
                return this.IsValidCredentials();
            });
        }

        private bool IsValidCredentials()
        {
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }
    }
}
