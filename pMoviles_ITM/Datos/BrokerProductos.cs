using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using pMoviles_ITM.Models;
using System.Threading.Tasks;

namespace pMoviles_ITM.Datos
{
    class BrokerProductos
    {
           private readonly SQLiteAsyncConnection oBaseDatos;

        public BrokerProductos(string RutaBD)
        {
            oBaseDatos = new SQLiteAsyncConnection(RutaBD);
        }
        public Task<List<viewProductos>> GetProductoss()
        {
            return oBaseDatos.Table<viewProductos>().ToListAsync();
        }
        public Task<viewProductos> GetProductosXID(int Id)
        {
            return oBaseDatos.Table<viewProductos>()
                .Where(vProductos => vProductos.ID == Id)
                .FirstOrDefaultAsync();
        }
      
        public Task<int> GrabarProductos(viewProductos vProductos)
        {
            if (vProductos.ID == 0)
            {
                return oBaseDatos.InsertAsync(vProductos);
            }
            else
            {
                return oBaseDatos.UpdateAsync(vProductos);
            }
        }
        public Task<int> EliminarProductos(viewProductos vProductos)
        {
            return oBaseDatos.DeleteAsync(vProductos);
        }
    }
}