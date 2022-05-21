using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using pMoviles_ITM.Models;

namespace pMoviles_ITM.Datos
{
    //Clase para crear las tablas de la base de datos
    public class clsBasesDatos
    {
        //Se crea la propiedad de conexion
        private SQLiteAsyncConnection oBaseDatos;
        private bool bTablaCliente, btablaProducto, bTablaPedidos;

        public clsBasesDatos(string RutaBD)
        {
            oBaseDatos = new SQLiteAsyncConnection(RutaBD);
            //una vez se compruebe la creacion de la bd, se colocan en false
            bTablaCliente = false;
            btablaProducto = false;
            bTablaPedidos = false;
        }
        public void CrearTablas()
        {

            if (bTablaCliente) { oBaseDatos.CreateTableAsync<viewCliente>().Wait(); }
            if (btablaProducto) { oBaseDatos.CreateTableAsync<viewProductos>().Wait(); }
            if (bTablaPedidos) { oBaseDatos.CreateTableAsync<viewPedidos>().Wait(); }
        }
    }
}
