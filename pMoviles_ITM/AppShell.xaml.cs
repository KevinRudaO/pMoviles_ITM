using pMoviles_ITM.ViewModels;
using pMoviles_ITM.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace pMoviles_ITM
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(Clientes), typeof(Clientes));
            Routing.RegisterRoute(nameof(ListadoClientes), typeof(ListadoClientes));
            Routing.RegisterRoute(nameof(Productos), typeof(Productos));
            Routing.RegisterRoute(nameof(Producto_Listado), typeof(Producto_Listado));
            Routing.RegisterRoute(nameof(TomaPedidos), typeof(TomaPedidos));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
