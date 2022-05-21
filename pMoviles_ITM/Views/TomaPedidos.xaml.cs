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

        public TomaPedidos()
        {
            InitializeComponent();
            lblFecha.Text = DateTime.Now.ToString("yyy-MM-dd");
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnConsultarXId_Clicked(object sender, EventArgs e)
        {

        }

        private void btnConsultarXDocumento_Clicked(object sender, EventArgs e)
        {

        }

        private void btnConsultarTodos_Clicked(object sender, EventArgs e)
        {

        }

       async private void btnConsultarCliente_Clicked(object sender, EventArgs e)
        {
            string Documento = txtDocumento.Text;
            viewCliente vCliete = await bCliente.GetClienteXDocumento(Documento);
            lblCliente.Text = vCliete.Nombres + " " + vCliete.Apellidos;
        }
    }
}