using pMoviles_ITM.Datos;
using pMoviles_ITM.Models;
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
    public partial class TomaPedidos : ContentPage
    {
        BrokerCliente bCliente = new BrokerCliente(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBMoviles_ITM.db3"));
        BrokerProductos bProductos = new BrokerProductos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBMoviles_ITM.db3"));
        BrokerPedidos bPedidos = new BrokerPedidos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBMoviles_ITM.db3"));

        public TomaPedidos()
        {
            InitializeComponent();
            lblFecha.Text = DateTime.Now.ToString("yyy-MM-dd");
            LlenarComboProductos();
        }
        async private void LlenarComboProductos()
        {
            cboProductos.ItemsSource = await bProductos.GetProductos();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

        }

       async private void btnConsultarCliente_Clicked(object sender, EventArgs e)
        {
            string Documento = txtDocumento.Text;
            viewCliente vCliete = await bCliente.GetClienteXDocumento(Documento);
            if (vCliete==null)
            {
              await DisplayAlert("Error de cliente", "El cliente: " + Documento + " no existe", "OK");
                lblCliente.Text = "";
            }
            else { 
                lblCliente.Text = vCliete.Nombres + " " + vCliete.Apellidos;
                lblIdCliente.Text = vCliete.ID.ToString();
            }
        }

        private void cboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selecciona un elemento del combo de productos y captura el valor
            viewProductos vProducto =(viewProductos) cboProductos.SelectedItem; //se hace casting a productos
            lblValorUnitario.Text = "$ " + vProducto.Valor.ToString("#,###");
        }

       async private void btnComprar_Clicked(object sender, EventArgs e)
        {
            int NumeroPedido, IdCliente, IdProducto, Cantidad;
            double ValorUnitario;
            string FechaPedido;

            FechaPedido = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            if (lblPedido.Text == "")
            {
                NumeroPedido = (int)await bPedidos.GetNumeroPedido();
                lblPedido.Text = NumeroPedido.ToString();
            }
            else
            {
                NumeroPedido = Convert.ToInt32(lblPedido.Text);
            }
            //Obtener los valores del xaml
            IdCliente = Convert.ToInt32(lblIdCliente.Text);
            viewProductos vProducto = (viewProductos) cboProductos.SelectedItem;
            IdProducto = vProducto.ID;
            ValorUnitario = vProducto.Valor;
            Cantidad = Convert.ToInt32(txtCantidad.Text);

            //Guardar datos en el objeto
            viewPedidos vPedidos = new viewPedidos();
            vPedidos.NumeroPedido = NumeroPedido;
            vPedidos.IDCliente = IdCliente;
            vPedidos.IDProducto = IdProducto;
            vPedidos.Fecha = FechaPedido;
            vPedidos.Cantidad = Cantidad;
            vPedidos.ValorUnitario = ValorUnitario;

            //Guardar datos en la tabla pedidos
             await bPedidos.GrabarPedidos(vPedidos);
            int? NroProductos = await bPedidos.GetPedidosxProducto((int)NumeroPedido);
            lblNumeroproductos.Text = NroProductos.ToString();
        }

        async private void btnCarrito_Clicked(object sender, EventArgs e)
        {
            //Navega a pagina carro compras
            int NumeroPedido = Convert.ToInt32(lblPedido.Text);
            await Shell.Current.GoToAsync($"CarroCompras?NumeroPedido={NumeroPedido}");
        }
    }
}