using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pMoviles_ITM.Models;
using pMoviles_ITM.Datos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace pMoviles_ITM.Views
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Clientes : ContentPage
    {
        BrokerCliente bCliente = new BrokerCliente(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBMoviles_ITM.db3"));
        public Clientes()
        {
            InitializeComponent();
        }

        async private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            string Documento,Nombre,Apellidos, Telefono,Email;
            
            Documento = txtDocumento.Text;
            Nombre = txtNombres.Text;
            Apellidos = txtApellidos.Text;
            Telefono = txtTelefono.Text;
            Email = txtEmail.Text;

            viewCliente vCliente = new viewCliente();
            vCliente.ID = 0;
            vCliente.Documento = Documento;
            vCliente.Nombres = Nombre;
            vCliente.Apellidos = Apellidos;
            vCliente.Telefono = Telefono;
            vCliente.Email = Email;

            await bCliente.GrabarCliente(vCliente);
            _ = DisplayAlert("Inserción Cliente", "Ingresado: " + Documento, "OK");
            NavegarListadoClientes();
        }

        async private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            int ID;
            string Documento, Nombre, Apellidos, Telefono, Email;
            if (txtID.Text == "")
            {
                await DisplayAlert("Error de actualización", "No definió ID a actualizar", "OK");
                return;
            }
            else
            {
                ID = Convert.ToInt32(txtID.Text);
                Documento = txtDocumento.Text;
                Nombre = txtNombres.Text;
                Apellidos = txtApellidos.Text;
                Telefono = txtTelefono.Text;
                Email = txtEmail.Text;

                viewCliente vCliente = new viewCliente();
                vCliente.ID = ID;
                vCliente.Documento = Documento;
                vCliente.Nombres = Nombre;
                vCliente.Apellidos = Apellidos;
                vCliente.Telefono = Telefono;
                vCliente.Email = Email;

                await bCliente.GrabarCliente(vCliente);
                _ = DisplayAlert("Actualización Cliente", "Actualizado: " + Documento, "OK");
            }
            NavegarListadoClientes();
        }
        
        async private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            int ID;
            ID = Convert.ToInt32(txtID.Text);

            viewCliente vCliente = new viewCliente();
            vCliente.ID = ID;

            await bCliente.EliminarCliente(vCliente);
            _ = DisplayAlert("Eliminacion Cliente", "Se eliminó el cliente ID: " + ID, "OK");
            NavegarListadoClientes();
        }

      async private void btnConsultarXId_Clicked(object sender, EventArgs e)
        {
            int ID;
            ID = Convert.ToInt32(txtID.Text);

            viewCliente vCliente = new viewCliente();
            vCliente = await bCliente.GetClienteXID(ID);
            if (vCliente != null)
            {
                txtDocumento.Text = vCliente.Documento;
                txtNombres.Text = vCliente.Nombres;
                txtApellidos.Text = vCliente.Apellidos;
                txtTelefono.Text = vCliente.Telefono;
                txtEmail.Text = vCliente.Email;
            }
            else
            {
                _ = DisplayAlert("Error de consulta", "El cliente: " + ID + " No existe", "OK");
            }
    }

        async private void btnConsultarXDocumento_Clicked(object sender, EventArgs e)
        {
            string Documento;
            Documento = txtDocumento.Text;
            
            viewCliente vCliente = new viewCliente();
            vCliente = await bCliente.GetClienteXDocumento(Documento);

            if (vCliente != null)
            {
                txtID.Text = vCliente.ID.ToString();
                txtNombres.Text = vCliente.Nombres;
                txtApellidos.Text = vCliente.Apellidos;
                txtTelefono.Text = vCliente.Telefono;
                txtEmail.Text = vCliente.Email;
            }
            else
            {
                _ = DisplayAlert("Error de consulta", "El cliente: " + Documento+" No existe", "OK");
            }
        }

        private void btnConsultarTodos_Clicked(object sender, EventArgs e)
        {
            NavegarListadoClientes();
        }
        async private void NavegarListadoClientes()
        {
          await Shell.Current.GoToAsync(nameof(ListadoClientes));
        }
    }
}