using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pMoviles_ITM.Datos;
using pMoviles_ITM.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pMoviles_ITM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListadoClientes : ContentPage
    {
        BrokerCliente bCliente = new BrokerCliente(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBMoviles_ITM.db3"));
        public ListadoClientes()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
          base.OnAppearing();
          lstClientes.ItemsSource = await bCliente.GetClientes();
        }
    }
}