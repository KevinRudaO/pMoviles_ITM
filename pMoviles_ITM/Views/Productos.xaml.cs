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
    public partial class Productos : ContentPage
    {
        BrokerProductos bProductos = new BrokerProductos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBMoviles_ITM.db3"));

        public Productos()
        {
            InitializeComponent();
        }

       async private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            string NombreProducto;
            int ID, ValorUnitario, Inventario;

            ID = 0;
            NombreProducto = txtNombres.Text;
            ValorUnitario =Convert.ToInt32(txtValor.Text);
            Inventario = Convert.ToInt32(txtInventario.Text);

            viewProductos vProductos = new viewProductos();
            vProductos.ID = ID;
            vProductos.Producto = NombreProducto;
            vProductos.Valor = ValorUnitario;
            vProductos.Inventario = Inventario;
            await bProductos.GrabarProductos(vProductos);

            _ = DisplayAlert("Inserción Productos", "Ingresado: " + NombreProducto, "OK");
            ListarProductos();
        }

        async private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            string NombreProducto;
            int ID, ValorUnitario, Inventario;

            ID = Convert.ToInt32(txtID.Text);
            NombreProducto = txtNombres.Text;
            ValorUnitario = Convert.ToInt32(txtValor.Text);
            Inventario = Convert.ToInt32(txtInventario.Text);

            viewProductos vProductos = new viewProductos();
            vProductos.ID = ID;
            vProductos.Producto = NombreProducto;
            vProductos.Valor = ValorUnitario;
            vProductos.Inventario = Inventario;
            await bProductos.GrabarProductos(vProductos);

            _ = DisplayAlert("Actualización de Producto", "Actualizado: " + NombreProducto, "OK");
            ListarProductos();

        }

       async private void btnConsultarXId_Clicked(object sender, EventArgs e)
        {
            int ID;
            ID = Convert.ToInt32(txtID.Text);

            viewProductos vProducto = new viewProductos();
            vProducto=await bProductos.GetProductosXID(ID);

            if (vProducto != null)
            {
                txtNombres.Text = vProducto.Producto;
                txtValor.Text = vProducto.Valor.ToString();
                txtInventario.Text = vProducto.Inventario.ToString();
            }
            else
            {
                _ = DisplayAlert("Error de consulta", "El Producto: " + ID + " No existe", "OK");
                txtNombres.Text = "";
                txtValor.Text = "";
                txtInventario.Text = "";
            }
        }

        private void btnConsultarTodos_Clicked(object sender, EventArgs e)
        {
            ListarProductos();
        }
        async private void ListarProductos()
        {
            await Shell.Current.GoToAsync(nameof(Producto_Listado));
        }

        async private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            int ID;
            string Nombre;
            ID = Convert.ToInt32(txtID.Text);
            Nombre = txtNombres.Text;

            bool respuesta = await DisplayAlert("Confirmación de borrado", "Esta seguro de eliminar: " + Nombre, "YES","NO");

            if (respuesta==true)
            {
                viewProductos vProductos = new viewProductos();
                vProductos.ID = ID;
                await bProductos.EliminarProductos(vProductos);
                _ = DisplayAlert("Eliminación de Producto", "Eliminado: " + ID, "OK");
                ListarProductos();
            }
            else
            {
                _ = DisplayAlert("OK", "No eliminado" + ID, "OK");
            }

            
        }
    }
}