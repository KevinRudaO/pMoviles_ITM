using pMoviles_ITM.Datos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pMoviles_ITM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Producto_Listado : ContentPage
    {
        BrokerProductos bProductos = new BrokerProductos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBMoviles_ITM.db3"));

        public Producto_Listado()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            lstProductos.ItemsSource = await bProductos.GetProductoss();
        }
    }
}