using ReserveCars.Models;
using Xamarin.Forms;

namespace ReserveCars.Views
{
    public partial class MasterDetailView : MasterDetailPage
    {
        public MasterDetailView(User user)
        {
            InitializeComponent();
            this.Master = new MasterView(user);
        }
    }
}