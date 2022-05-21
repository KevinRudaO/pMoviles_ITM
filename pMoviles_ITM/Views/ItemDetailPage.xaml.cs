using pMoviles_ITM.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace pMoviles_ITM.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}