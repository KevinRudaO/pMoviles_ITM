using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using pMoviles_ITM.Datos;
using System.IO;

namespace pMoviles_ITM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(NumeroPedido),"NumeroPedido")]
    public partial class CarroCompras : ContentPage
    {
        BrokerPedidos bPedidos = new BrokerPedidos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBMoviles_ITM.db3"));

        public CarroCompras()
        {
            InitializeComponent();
        }

        public int NumeroPedido
        {
            set { LlenarListaPedido(value); }
        }
         async private void LlenarListaPedido(int NumeroPedido)
        {
            lstProductos.ItemsSource = await bPedidos.GetPedidosXNumero(NumeroPedido);
        }

    }
}